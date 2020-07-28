using System;

namespace leetcode.Medium
{
    public partial class Solution
    {
        public bool CheckOverlap_v1(int radius, int x_center, int y_center, int x1, int y1, int x2, int y2)
        {
            if (x_center + radius < x1 || x_center - radius > x2 ||
                y_center + radius < y1 || y_center - radius > y2) return false;

            // ���ж�Բ�ĵ��������ĵľ��� �� Բ�İ뾶�Ӿ��ζԽ���һ�볤�� �Ĵ�С
            double s = Math.Sqrt(Math.Pow(x_center - (x2 + x1) / 2, 2) + Math.Pow(y_center - (y2 + y1) / 2, 2));
            double l = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) / 2 + radius;

            return s <= l;
        }

        //https://www.zhihu.com/question/24251545;
        public bool CheckOverlap_v2(int radius, int x_center, int y_center, int x1, int y1, int x2, int y2)
        {
            //ת������1����;
            var tempV_x = Math.Abs(x_center - x1);
            var tempV_y = Math.Abs(y_center - y1);
            //��Բ�������ε���̾���ʸ��;
            var tempU_x = Math.Max(tempV_x - x2, 0);
            var tempU_y = Math.Max(tempV_y - y2, 0);
            //����ƽ����뾶ƽ���Ƚ�;
            return tempU_x * tempU_x + tempU_y * tempU_y <= radius * radius;
        }
    }
}