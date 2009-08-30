var _basePath = "/ninject/";
var _routeTemplates = {
  "community": {
    "show": "/ninject/community"
  },
  "contribute": {
    "show": "/ninject/contribute"
  },
  "download": {
    "show": "/ninject/download"
  },
  "error": {
    "show": "/ninject/error/{code}",
    "shownotfound": "/ninject/{*url}"
  },
  "extensions": {
    "show": "/ninject/extensions"
  },
  "home": {
    "show": "/ninject/"
  },
  "learn": {
    "show": "/ninject/learn"
  },
  "merchandise": {
    "show": "/ninject/merchandise"
  },
  "sponsors": {
    "show": "/ninject/sponsors"
  }
};

var urlfor = function(action, controller, values) {
	values = values || {};

	if (typeof(_routeTemplates[controller]) == 'undefined' || typeof(_routeTemplates[controller][action]) == 'undefined') {
		return null;
	}

	var template = _routeTemplates[controller][action];
	var tokens = template.match(/{[^}]+}/g);
	
	if (!tokens) { return template; }
	
	var url = template;
	for (var idx = 0; idx < tokens.length; idx++) {
		var token = tokens[idx];
		var name = token.substring(1, token.length - 1);

		var value = null;

		if (name == 'controller') {	value = controller; }
		else if (name == 'action') { value = action; }
		else if (typeof(values[name]) != 'undefined') { value = values[name]; }

		if (value != null) {
			url = url.replace(token, value);
		}
	}
	
	return url;
};
var imageurl = function(filename) {
	return _basePath + 'content/images/' + filename;
};