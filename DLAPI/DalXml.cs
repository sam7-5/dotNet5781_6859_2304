﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DLAPI;
using DO;

namespace DLAPI
{
    sealed class DalXml //:idl
    {
        #region singelton
        static readonly DalXml instance = new DalXml();
        static DalXml() { }// static ctor to ensure instance init is done just before first usage
        DalXml() { } // default => private
        public static DalXml Instance { get => instance; }// The public Instance property to use
        #endregion

        #region DS XML Files

        string personsPath = @"PersonsXml.xml"; //XElement

        string studentsPath = @"StudentsXml.xml"; //XMLSerializer
        string coursesPath = @"CoursesXml.xml"; //XMLSerializer
        string lecturersPath = @"LecturersXml.xml"; //XMLSerializer
        string lectInCoursesPath = @"LecturerInCourseXml.xml"; //XMLSerializer
        string studInCoursesPath = @"StudentInCoureseXml.xml"; //XMLSerializer


        #endregion
    }
}
