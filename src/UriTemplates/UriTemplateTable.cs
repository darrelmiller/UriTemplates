﻿using System;
using System.Collections.Generic;

namespace Tavis.UriTemplates
{
    public class UriTemplateTable
    {
        private readonly Dictionary<string,UriTemplate> _Templates =  new Dictionary<string,UriTemplate>();
        
        public void Add(string key, UriTemplate template)
        {
            _Templates.Add(key,template);
        }

        public TemplateMatch Match(Uri url)
        {
            foreach (var template in _Templates )
            {
                var parameters = template.Value.GetParameters(url);
                if (parameters != null)
                {
                    return new TemplateMatch { Key = template.Key, Parameters = parameters, Template = template.Value };
                }
            }
            return null;
        }

        public UriTemplate this[string key] => _Templates.TryGetValue(key, out var value)
            ? value
            : null;
    }

    public class TemplateMatch
    {
        public string Key { get; set; }
        public UriTemplate Template {get;set;}
        public IDictionary<string,object> Parameters {get;set;}
    }
}
