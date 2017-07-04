using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Interfaces {
    public interface IImageResize {
        byte[] ResizeImage(byte[] imageData);
        byte[] ResizeImage(byte[] imageData, float width, float height);
    }
}
