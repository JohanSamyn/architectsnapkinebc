using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace conversions.tests
{
    [TestFixture]
    public class use_StringToDictionaryConverter
    {
        [Test]
        public void Run_sample_usage()
        {
            var cnv = new StringToDictionaryConverter();

            var dict = cnv.Convert("port=8080;user =foo;password=bar;");

            Assert.That(dict, Is.EqualTo(new Dictionary<string, string>
                                             {
                                                 {"port", "8080"},
                                                 {"user", "foo"},
                                                 {"password", "bar"}
                                             }));
        }


        [Test]
        public void Run_sample_with_extension_method_on_string()
        {
            var dict = "port=8080;user=foo;password=bar".ToDictionary();
  
            Assert.That(dict, Is.EqualTo(new Dictionary<string, string>
                                                {
                                                    {"port", "8080"},
                                                    {"user", "foo"},
                                                    {"password", "bar"}
                                                }));
        }


        [Test]
        public void Run_sample_with_extension_method_on_dict()
        {
            var dict = new Dictionary<string, string> {{"server", "localhost"}};

            dict.Parse("port=8080;user=foo;password=bar");

            Assert.That(dict, Is.EqualTo(new Dictionary<string, string>
                                             {
                                                 {"server", "localhost"},
                                                 {"port", "8080"},
                                                 {"user", "foo"},
                                                 {"password", "bar"}
                                             }));
        }

    }
}
