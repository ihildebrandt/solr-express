﻿using Xunit;
using SolrExpress.Core.Search.ParameterValue;

namespace SolrExpress.Core.UnitTests.Search.ParameterValue
{
    public class QueryAllTests
    {
        /// <summary>
        /// Where   Using a QueryAll instance
        /// When    Create the instance
        /// What    Get "*:*" value
        /// </summary>
        [Fact]
        public void QueryAll001()
        {
            // Arrange
            var expected = "*:*";
            string actual;
            var parameter = new QueryAll<TestDocument>();

            // Act
            actual = parameter.Execute();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
