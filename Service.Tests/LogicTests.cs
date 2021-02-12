using System;
using Xunit;

namespace Service.Tests
{
    public class LogicTests
    {
        //---------------------------Start of Mapper Tests------------------------

        /// <summary>
        /// Tests the ConvertImage() method of Mapper
        /// </summary>
        /// 
        [Fact]
        public void TestForConvertImage()
        {
            Mapper mapper = new Mapper();
            string textSting = "text,text";
            var convert = mapper.ConvertImage(textSting);

            Assert.IsType<byte[]>(convert);
            Assert.NotNull(convert);
        }

        //----------------------------End of Mapper tests-------------------------

        //--------------------------Start of LogicClass Tests---------------------


        //--------------------------End of LogicClass Tests-----------------------
    }
}
