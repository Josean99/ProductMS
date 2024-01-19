using EntityService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Fakes.Entities
{
    public static class TextFake
    {
        public static Text GenerateFakeText()
        {
            var fakeText = new Text
            {
                Id = Guid.NewGuid(),
                Code = "FakeCode",
                Value = "Fake Text Value"
            };

            return fakeText;
        }
    }

}
