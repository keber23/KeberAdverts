using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalTests.Web.Controllers
{
    public class CatalogControllerGetImage : BaseWebTest
    {
        //[Fact]
        // GetImage replaced by static file middleware
        public async Task ReturnsFileContentResultGivenValidId()
        {
            var testFilePath = Path.Combine(_contentRoot, "pics//1.png");
            var expectedFileBytes = File.ReadAllBytes(testFilePath);

            var response = await _client.GetAsync("/catalog/pic/1");
            response.EnsureSuccessStatusCode();
            var streamResponse = await response.Content.ReadAsStreamAsync();
            byte[] byteResult;
            using (var ms = new MemoryStream())
            {
                streamResponse.CopyTo(ms);
                byteResult = ms.ToArray();
            }

            Assert.Equal(expectedFileBytes, byteResult);
        }
    }
}
