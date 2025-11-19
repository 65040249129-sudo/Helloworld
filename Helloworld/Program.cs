using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Helloworld
{
    internal class Program
    {
        // ------------------------------------------------------------------
        // ##ฟังก์ชันสำหรับรับและตรวจสอบข้อมูล (Validation Methods)
        // ------------------------------------------------------------------

        // ฟังก์ชัน 1: รับชื่อภาษาอังกฤษ (ต้องมีความยาว >= 2)
        static string GetValidNameInput()
        {
            string name = string.Empty;
            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine("Please input your name (Eng).");
                name = Console.ReadLine().Trim();

                // ตรวจสอบเงื่อนไข 3 ข้อ: 1.ไม่ว่าง 2.ยาว >= 2 3.เป็นตัวอักษร Eng เท่านั้น
                if (!string.IsNullOrWhiteSpace(name) &&
                    name.Length >= 2 &&
                    Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
                {
                    isValid = true;
                }
                // ถ้าไม่ถูกต้อง จะวนซ้ำการถามคำถามเดิมทันที
            }
            return name;
        }

        // ฟังก์ชัน 2: รับเพศ (ต้องเป็น 'M' หรือ 'F' เท่านั้น)
        static string GetValidGenderInput()
        {
            string genderInitial = string.Empty;
            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine("Please input your gender (M/F).");
                genderInitial = Console.ReadLine().ToUpper().Trim();

                // ตรวจสอบเงื่อนไข: ต้องเป็น 'M' หรือ 'F'
                if (genderInitial == "M" || genderInitial == "F")
                {
                    isValid = true;
                }
            }
            return genderInitial;
        }

        // ฟังก์ชัน 3: รับส่วนสูงเป็นเซนติเมตร (ต้องเป็นตัวเลขและมีค่ามากกว่า 50)
        static int GetValidHeightInput()
        {
            int height = 0;
            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine("Please input your height (cm).");
                string input = Console.ReadLine();

                // ตรวจสอบเงื่อนไข: 1.แปลงเป็น int ได้ 2.มีค่ามากกว่า 50
                if (int.TryParse(input, out height) && height > 50)
                {
                    isValid = true;
                }
            }
            return height;
        }

        // ------------------------------------------------------------------
        // ##ส่วนหลักของโปรแกรม (Main Program)
        // ------------------------------------------------------------------
        static void Main()
        {
            Console.WriteLine("Hello world");
            bool exitProgram = false;

            // ลูปหลัก: โปรแกรมจะทำงานซ้ำไปเรื่อยๆ จนกว่าผู้ใช้จะกด 'Q'
            while (!exitProgram)
            {
                // **1. เริ่มรับข้อมูลโดยเรียกใช้ฟังก์ชันย่อย**
                Console.WriteLine("=======================================");
                Console.WriteLine("--- ป้อนข้อมูล ---");

                string name = GetValidNameInput();
                Console.WriteLine($"Hello, welcome {name}");

                string genderInitial = GetValidGenderInput();
                int height = GetValidHeightInput();

                // **2. คำนวณน้ำหนักที่เหมาะสม**
                int resultWeight;
                string genderType;

                if (genderInitial == "M")
                {
                    resultWeight = height - 100; // สูตรสำหรับผู้ชาย
                    genderType = "Male";
                }
                else
                {
                    resultWeight = height - 110; // สูตรสำหรับผู้หญิง
                    genderType = "Female";
                }

                // **3. แสดงผลลัพธ์**
                Console.WriteLine("=======================================");
                Console.WriteLine($"ข้อมูลถูกต้อง: {name} ({genderType}) accepted.");
                Console.WriteLine($"Calculated ideal weight: {resultWeight} kg");
                Console.WriteLine("=======================================");

                // **4. ควบคุมการจบโปรแกรม**
                Console.WriteLine("Press 'Q' to exit, or press any other key to input new data...");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Q)
                {
                    exitProgram = true;
                }
                Console.WriteLine();
            }

            Console.WriteLine("Program ended. Goodbye!");
        }
    }
}

