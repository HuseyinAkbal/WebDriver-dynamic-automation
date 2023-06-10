using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;

namespace SonHal
{

    public class DeserializationSide
    {
        public SeleniumStepsDTO GetSideData(string icerikForm)
        {

            var seleniumDto = new SeleniumStepsDTO();

            try
            {
                var desdata = JsonConvert.DeserializeObject<DataModel>(icerikForm);

                if (desdata != null)
                {
                    seleniumDto.Url = desdata.url;
                    var commandList = new List<CommandDTO>();




                    foreach (var test in desdata.tests)
                    {

                        foreach (var command in test.commands)
                        {
                            var added = new CommandDTO
                            {
                                Command = command.command,
                                Target = command.target,
                                Value = command.value,
                            };

                            commandList.Add(added);
                        }
                    }

                    seleniumDto.Commands = commandList;
                }

            }

            catch (Exception e)
            {

                Console.WriteLine("Hata: Side dosyası seçiniz " + e.Message);
            }

            return seleniumDto;
        }

    }
}