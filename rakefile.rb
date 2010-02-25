COMPILE_TARGET = "debug";
RESULTS_DIR = "results";
BUILD_NUMBER = "0.1.0.";
COMPANY = "Enkari, Ltd.";
PRODUCT = "Ninject Website";
COPYRIGHT = "Copyright ©2009 Enkari, Ltd. All rights reserved.";
COMMON_ASSEMBLY_INFO = "src/CommonAssemblyInfo.cs";
CLR_VERSION = "v3.5";
SOLUTION_FILE = "Ninject.Website.sln";
CSS_DIR = "src/ninject.website/content/css/";
JS_DIR = "src/ninject.website/content/js/";
CSS_MANIFEST_FILE = "config/stylesheets.txt";
JS_MANIFEST_FILE = "config/scripts.txt";
CSS_BUNDLE_FILE = "bundle.css";
JS_BUNDLE_FILE = "bundle.js";

require "rake"
require "yaml"
require "less"
require "buildutils.rb"

include FileTest

versionNumber = ENV["BUILD_NUMBER"].nil? ? 0 : ENV["BUILD_NUMBER"]

props = { :archive => "build" }

desc "Compiles and tests"
task :all => [:default]

desc "Compiles and tests"
task :default => [:compile, :test]

desc "Displays a list of tasks"
task :help do
  taskHash = Hash[*(`rake -T`.split(/\n/).collect { |l| l.match(/rake (\S+)\s+\#\s(.+)/).to_a }.collect { |l| [l[1], l[2]] }).flatten] 
 
  indent = "                          "
  
  puts "rake #{indent}# Runs the 'default' task"
  
  taskHash.each_pair do |key, value|
    if key.nil?  
      next
    end
    puts "rake #{key}#{indent.slice(0, indent.length - key.length)}# #{value}"
  end
end

desc "Update the version information for the build"
task :version do
  builder = AsmInfoBuilder.new(BUILD_NUMBER, {'Product' => PRODUCT, 'Company' => COMPANY, 'Copyright' => COPYRIGHT})
  buildNumber = builder.buildnumber
  puts "The build number is #{buildNumber}"
  builder.write COMMON_ASSEMBLY_INFO  
end

desc "Prepares the working directory for a new build"
task :clean do
	Dir.mkdir props[:archive] unless exists?(props[:archive])
	FileList['**/bin'].each { |d| remove_dir(d, force = true) }
end

desc "Compiles the app"
task :compile => [:clean, :version] do
  MSBuildRunner.compile :compilemode => COMPILE_TARGET, :solutionfile => SOLUTION_FILE, :clrversion => CLR_VERSION
    
  outDir = "bin/#{COMPILE_TARGET}"
    
  Dir.glob(File.join(outDir, "*.{dll,pdb}")) do |file|
		copy(file, props[:archive]) if File.file?(file)
  end
end

desc "Runs unit tests"
task :test => :compile do
  runner = NUnitRunner.new :compilemode => COMPILE_TARGET, :source => '.'
  runner.executeTests FileList['*Tests*']
end

desc "Minifies and bundles CSS and javascript"
task :minify => [ :minify_css, :minify_js ]

desc "Converts LESS templates to a minified bundle of CSS"
task :minify_css do
	puts "Minifying and bundling CSS/LESS files:"
	path = File.join(File.dirname(__FILE__), CSS_DIR)
	bundle = File.join(path, CSS_BUNDLE_FILE)
	File.open(bundle, "w") do |f|
		compressor = IO.popen("java -jar tools/yuicompressor-2.4.2.jar --type css", "w+")
		File.new(CSS_MANIFEST_FILE).readlines.each do |infile|
			puts "  + #{infile}"
			input = IO.read(File.join(path, infile.chomp))
			compressor.puts Less::Engine.new(input).to_css
		end
		compressor.close_write
		f.write(compressor.gets)
	end
	puts "Wrote CSS bundle to #{bundle}."
end

desc "Bundles and minifies javascript"
task :minify_js do
	puts "Minifying and bundling javascript files:"
	path = File.join(File.dirname(__FILE__), JS_DIR)
	bundle = File.join(path, JS_BUNDLE_FILE)
	File.open(bundle, "w") do |f|
		compressor = IO.popen("java -jar tools/yuicompressor-2.4.2.jar --type js", "w+")
		File.new(JS_MANIFEST_FILE).readlines.each do |infile|
			puts "  + #{infile}"
			compressor.puts IO.read(File.join(path, infile.chomp))
		end
		compressor.close_write
		f.write(compressor.gets)
	end
	puts "Wrote javascript bundle to #{bundle}."
end