using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyLib;
using System.IO;
using System.Text;

namespace Decorators.Tests
{
    [TestClass]
    public class BufferStreamDecoratorTests
    {
        private Stream DecoratedStream { get; set; }
        private BufferStreamDecorator Decorator { get; set; }

        [TestInitialize]
        public void Setup()
        {
            DecoratedStream = new MemoryStream();
            byte[] closingBytes = new byte[] { 0x78, 0x79, 0x7A }; // Пример запрещенных байт
            Decorator = new BufferStreamDecorator(DecoratedStream, closingBytes);
        }

        //    [TestMethod]
        //    public void Write_NoForbiddenBytes_WritesToDecoratedStream()
        //    {
        //        // Arrange
        //        byte[] buffer = new byte[] { 1, 2, 3 };

        //        // Act
        //        Decorator.Write(buffer, 0, buffer.Length);

        //        // Assert
        //        byte[] writtenData = ((MemoryStream)DecoratedStream).ToArray();
        //        CollectionAssert.AreEqual(buffer, writtenData);
        //        Assert.IsFalse(Decorator.CombinationDetected);
        //    }

        //    [TestMethod]
        //    public void Write_ForbiddenBytes_CombinationDetected()
        //    {
        //        // Arrange
        //        byte[] buffer = new byte[] { 1, 2, 0x78, 4 }; // Содержит запрещенный байт 0x78

        //        // Act
        //        Decorator.Write(buffer, 0, buffer.Length);

        //        // Assert
        //        byte[] writtenData = ((MemoryStream)DecoratedStream).ToArray();
        //        byte[] expectedData = new byte[] { 1, 2 }; // Запись должна прекратиться при обнаружении запрещенного байта
        //        Assert.AreEqual(expectedData.Length, writtenData.Length);
        //        for (int i = 0; i < expectedData.Length; i++)
        //        {
        //            Assert.AreEqual(expectedData[i], writtenData[i]);
        //        }
        //        Assert.IsTrue(Decorator.CombinationDetected);
        //    }

        //    [TestMethod]
        //    public void Write_MultipleWritesWithForbiddenBytes_CombinationDetected()
        //    {
        //        // Arrange
        //        byte[] buffer1 = new byte[] { 1, 2, 0x78, 4 }; // Содержит запрещенный байт 0x78
        //        byte[] buffer2 = new byte[] { 0x79, 6, 7 };
        //        byte[] buffer3 = new byte[] { 8, 9, 0x7A }; // Содержит запрещенный байт 0x7A

        //        // Act
        //        Decorator.Write(buffer1, 0, buffer1.Length);
        //        Decorator.Write(buffer2, 0, buffer2.Length);
        //        Decorator.Write(buffer3, 0, buffer3.Length);

        //        // Assert
        //        byte[] writtenData = ((MemoryStream)DecoratedStream).ToArray();
        //        byte[] expectedData = new byte[] { 1, 2 }; // Запись должна прекратиться при обнаружении запрещенных байтов
        //        CollectionAssert.AreEqual(expectedData, writtenData, $"Expected: {BitConverter.ToString(expectedData)}, Actual: {BitConverter.ToString(writtenData)}");
        //        Assert.IsTrue(Decorator.CombinationDetected);
        //    }
        //}
    }
}
