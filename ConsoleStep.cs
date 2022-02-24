using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucking
{
    public enum Model
    {
        Role = 1, Driver, Company, Park, ParkService, Technique, Schedule
    }

    public enum ModelCrud
    {
        Read = 1, Create, Update, Delete
    }

    class ConsoleStep
    {
        public void Interaction(Db db)
        {
            string model = "", crudCommad = "";

            model = ChooseModel();
            crudCommad = CrudCommand();
            Perfom(model, crudCommad, db);

            Interaction(db);
        }

        public string ChooseModel()
        {
            Console.WriteLine($"{(int)Model.Role} - Role\n" +
                              $"{(int)Model.Driver} - Driver\n" +
                              $"{(int)Model.Company} - Company\n" +
                              $"{(int)Model.Park} - Park\n" +
                              $"{(int)Model.ParkService} - Park Service\n" +
                              $"{(int)Model.Technique} - Technique\n" +
                              $"{(int)Model.Schedule} - Schedules");

            return ReadCommand();
        }

        public void Perfom(string model, string crudCommand, Db db)
        {
            Model enumModel = (Model)int.Parse(model);
            ModelCrud enumCrud = (ModelCrud)int.Parse(crudCommand);

            if (enumModel == Model.Role)
            {
                Role obj = new Role(db);
                RoleCrud(enumCrud, obj);
            }
            else if (enumModel == Model.Driver)
            {
                Driver obj = new Driver(db);
                DriverCrud(enumCrud, obj);
            }
            else if (enumModel == Model.Company)
            {
                Company obj = new Company(db);
                CompanyCrud(enumCrud, obj);
            }
            else if (enumModel == Model.Park)
            {
                Park obj = new Park(db);
                ParkCrud(enumCrud, obj);
            }
            else if (enumModel == Model.ParkService)
            {
                ParkService obj = new ParkService(db);
                ParkServiceCrud(enumCrud, obj);
            }
            else if (enumModel == Model.Technique)
            {
                Technique obj = new Technique(db);
                TechniqueCrud(enumCrud, obj);
            }
            else if (enumModel == Model.Schedule)
            {
                Schedule obj = new Schedule(db);
                ScheduleCrud(enumCrud, obj);
            }
        }

        public void RoleCrud(ModelCrud modelCrud, Role obj)
        {
            if (modelCrud == ModelCrud.Read)
            {
                obj.GetAll();
            }
            else if (modelCrud == ModelCrud.Create)
            {
                string[] inputParams = InputParamas();

                obj.Insert(inputParams[0]);
            }
            else if (modelCrud == ModelCrud.Update)
            {
                string[] inputParams = InputParamas();

                obj.Update(int.Parse(inputParams[0]), inputParams[1]);
            }
            else if (modelCrud == ModelCrud.Delete)
            {
                string[] inputParams = InputParamas();

                obj.Delete(int.Parse(inputParams[0]));
            }
        }

        public void DriverCrud(ModelCrud modelCrud, Driver obj)
        {
            if (modelCrud == ModelCrud.Read)
            {
                obj.GetAll();
            }
            else if (modelCrud == ModelCrud.Create)
            {
                string[] inputParams = InputParamas();

                obj.Insert(inputParams[0], inputParams[1], int.Parse(inputParams[2]), inputParams[3], int.Parse(inputParams[4]));
            }
            else if (modelCrud == ModelCrud.Update)
            {
                string[] inputParams = InputParamas();

                obj.Update(int.Parse(inputParams[0]), inputParams[1]);
            }
            else if (modelCrud == ModelCrud.Delete)
            {
                string[] inputParams = InputParamas();

                obj.Delete(int.Parse(inputParams[0]));
            }
        }

        public void CompanyCrud(ModelCrud modelCrud, Company obj)
        {
            if (modelCrud == ModelCrud.Read)
            {
                obj.GetAll();
            }
            else if (modelCrud == ModelCrud.Create)
            {
                string[] inputParams = InputParamas();

                obj.Insert(int.Parse(inputParams[0]), inputParams[1], inputParams[2]);
            }
            else if (modelCrud == ModelCrud.Update)
            {
                string[] inputParams = InputParamas();

                obj.Update(int.Parse(inputParams[0]), inputParams[1]);
            }
            else if (modelCrud == ModelCrud.Delete)
            {
                string[] inputParams = InputParamas();

                obj.Delete(int.Parse(inputParams[0]));
            }
        }

        public void ParkCrud(ModelCrud modelCrud, Park obj)
        {
            if (modelCrud == ModelCrud.Read)
            {
                obj.GetAll();
            }
            else if (modelCrud == ModelCrud.Create)
            {
                string[] inputParams = InputParamas();

                obj.Insert(int.Parse(inputParams[0]), int.Parse(inputParams[1]));
            }
            else if (modelCrud == ModelCrud.Update)
            {
                string[] inputParams = InputParamas();

                obj.Update(int.Parse(inputParams[0]), int.Parse(inputParams[1]));
            }
            else if (modelCrud == ModelCrud.Delete)
            {
                string[] inputParams = InputParamas();

                obj.Delete(int.Parse(inputParams[0]));
            }
        }

        public void ParkServiceCrud(ModelCrud modelCrud, ParkService obj)
        {
            if (modelCrud == ModelCrud.Read)
            {
                obj.GetAll();
            }
            else if (modelCrud == ModelCrud.Create)
            {
                string[] inputParams = InputParamas();

                obj.Insert(int.Parse(inputParams[0]));
            }
            else if (modelCrud == ModelCrud.Update)
            {
                string[] inputParams = InputParamas();

                obj.Update(int.Parse(inputParams[0]), int.Parse(inputParams[1]));
            }
            else if (modelCrud == ModelCrud.Delete)
            {
                string[] inputParams = InputParamas();

                obj.Delete(int.Parse(inputParams[0]));
            }
        }

        public void TechniqueCrud(ModelCrud modelCrud, Technique obj)
        {
            if (modelCrud == ModelCrud.Read)
            {
                obj.GetAll();
            }
            else if (modelCrud == ModelCrud.Create)
            {
                string[] inputParams = InputParamas();

                obj.Insert(int.Parse(inputParams[0]), inputParams[0]);
            }
            else if (modelCrud == ModelCrud.Update)
            {
                string[] inputParams = InputParamas();

                obj.Update(int.Parse(inputParams[0]), inputParams[1]);
            }
            else if (modelCrud == ModelCrud.Delete)
            {
                string[] inputParams = InputParamas();

                obj.Delete(int.Parse(inputParams[0]));
            }
        }

        public void ScheduleCrud(ModelCrud modelCrud, Schedule obj)
        {
            if (modelCrud == ModelCrud.Read)
            {
                obj.GetAll();
            }
            else if (modelCrud == ModelCrud.Create)
            {
                string[] inputParams = InputParamas();

                obj.Insert(int.Parse(inputParams[0]), inputParams[1], inputParams[2], inputParams[3]);
            }
            else if (modelCrud == ModelCrud.Update)
            {
                string[] inputParams = InputParamas();

                obj.Update(int.Parse(inputParams[0]), inputParams[1]);
            }
            else if (modelCrud == ModelCrud.Delete)
            {
                string[] inputParams = InputParamas();

                obj.Delete(int.Parse(inputParams[0]));
            }
        }

        public string CrudCommand()
        {
            Console.WriteLine($"{(int)ModelCrud.Read} - Read\n" +
                              $"{(int)ModelCrud.Create} - Create\n" +
                              $"{(int)ModelCrud.Update} - Update\n" +
                              $"{(int)ModelCrud.Delete} - Delete\n");

            return ReadCommand();
        }

        private string ReadCommand()
        {
            Console.Write("Enter command: ");
            string command = Console.ReadLine();
            return command;
        }

        private string[] InputParamas()
        {
            Console.WriteLine("EnterParams through dots:\n\t");
            string inputParamsString = Console.ReadLine();

            char[] separators = { '.' };
            string[] inputParams = inputParamsString.Split(separators);

            return inputParams;
        }
    }
}
