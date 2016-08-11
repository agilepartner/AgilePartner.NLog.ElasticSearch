using AgilePartner.NLog.ElasticSearch;
using FluentAssertions;
using System;
using Xunit;

namespace Providing
{
    public class UriTest
    {
        protected void AssertUri(string uri, bool expectedResult)
        {
            Uri resultUri = null;
            var result = UriHelper.TryCreateUri(uri, out resultUri);

            result.Should().Be(expectedResult);

            if (expectedResult)
            {
                resultUri.Should().NotBeNull();
            }
        }
    }

    public class An_absolute_http_uri : UriTest
    {
        [Fact]
        public void Is_valid()
        {
            AssertUri("http://localhost:9200", true);
        }
    }

    public class An_absolute_https_uri : UriTest
    {
        [Fact]
        public void Is_valid()
        {
            AssertUri("https://localhost:9200", true);
        }
    }

    public class A_relative_uri : UriTest
    {
        [Fact]
        public void Is_not_valid()
        {
            AssertUri("localhost:9200", false);
        }
    }

    public class A_non_uri : UriTest
    {
        [Fact]
        public void Is_not_valid()
        {
            AssertUri("I am not an uri", false);
        }
    }
}
