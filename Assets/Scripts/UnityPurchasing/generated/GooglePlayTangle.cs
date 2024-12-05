// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("HkbUXGM0rmzeNKLc+iO5iCfPX0UQXjEL+gk45x8H7yPml5mYd8+Ae4QFqYTTeNS9EodaJ4qau0rDKIygoouHVIM6loIACh6xNL0VGlwTKS2SER8QIJIRGhKSEREQpNYQujs3Tb/zNsMy3O9jeYJn5pksmvpWdo+CCkoZngcr6CyFHB15HmMXjq0rXzKHKkZBVImk+S/Ojzlg5rIfcOV3S3snohNmqulKMkpNISAw6+y6DpNyIJIRMiAdFhk6lliW5x0REREVEBPzNz09PdhdCDp11GOm+rXOYYoagiLpmJseO61icABVnvkl1a/0NXg3QBkcocTkJyhQgTlWwph+ZnK6SU/feWnjU4zhEMqI6E7se+zZFOcwUjae91P9YPQ9bxITERAR");
        private static int[] order = new int[] { 9,10,2,11,10,6,11,10,12,9,10,11,13,13,14 };
        private static int key = 16;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
