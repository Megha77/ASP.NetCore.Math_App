namespace MathApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.Run(async (HttpContext context) => {
            //    if (context.Request.Method == "GET" && context.Request.Path=="/")
            //    {
            //        int firstNumber = 0, secondNumber = 0;
            //        long? result = null;
            //        string? operation = null;

            //        if (context.Request.Query.ContainsKey("firstNumber"))
            //        {
            //            string firstNumberString = context.Request.Query["firstNumber"][0];
            //            if (!string.IsNullOrEmpty(firstNumberString))
            //            {
            //                firstNumber = int.Parse(firstNumberString);
            //            }
            //            else
            //            {
            //                if (context.Response.StatusCode == 200)
            //                    context.Response.StatusCode = 400;
            //                await context.Response.WriteAsync("Invalid Input 'firstNumber' \n");
            //            }
            //        }
            //        else
            //        {
            //            if (context.Response.StatusCode == 200)
            //                context.Response.StatusCode = 400;
            //            await context.Response.WriteAsync("Invalid input for 'firstNumber'\n");
            //        }


            //        if (context.Request.Query.ContainsKey("secondNumber"))
            //        {
            //            string secondNumberString = context.Request.Query["secondNumber"][0];
            //            if (!string.IsNullOrEmpty(secondNumberString))
            //            {
            //                secondNumber = int.Parse(secondNumberString);
            //            }
            //            else
            //            {
            //                if (context.Response.StatusCode == 200)
            //                    context.Response.StatusCode = 400;
            //                await context.Response.WriteAsync("Invalid Input 'secondNumber' \n");
            //            }
            //        }
            //        else
            //        {
            //            if (context.Response.StatusCode == 200)
            //                context.Response.StatusCode = 400;
            //            await context.Response.WriteAsync("Invalid Input 'secondNumber' \n");
            //        }

            //        if (context.Request.Query.ContainsKey("operation"))
            //        {
            //            operation = Convert.ToString(context.Request.Query["operation"][0]);

            //            switch (operation)
            //            {
            //                case "add": result = firstNumber + secondNumber; break;
            //                case "subtract": result=firstNumber-secondNumber; break;
            //                case "multiply": result=firstNumber*secondNumber; break;
            //                case "divide": result=(secondNumber!=0) ? firstNumber/secondNumber :0; break;
            //                case "mod": result= (secondNumber!=0) ? firstNumber%secondNumber :0; break;
            //            }

            //            if (result.HasValue)
            //            {
            //                await context.Response.WriteAsync("Result: " + result.Value.ToString());
            //            }
            //            else
            //            {
            //                if (context.Response.StatusCode == 200)
            //                    context.Response.StatusCode = 400;
            //                await context.Response.WriteAsync("Invalid Input 'operation'\n");
            //            }                       

            //        }
            //        else
            //        {
            //            if (context.Response.StatusCode == 200)
            //                context.Response.StatusCode = 400;
            //            await context.Response.WriteAsync("Invalid Input 'operation' \n");
            //        }

            //    }
            //});

            app.Run(async (HttpContext context) => {

                if (context.Request.Method == "GET" && context.Request.Path == "/")
                {
                    int firstNumber = 0;
                    int secondNumber = 0;
                    long? result = null;
                    string? operation = null;

                    if (context.Request.Query.ContainsKey("firstNumber"))
                    {
                        string firstNumberString = context.Request.Query["firstNumber"][0];
                        if (!string.IsNullOrEmpty(firstNumberString))
                        {
                            firstNumber = int.Parse(firstNumberString);
                        }
                        else
                        {
                            if (context.Response.StatusCode == 200)
                                context.Response.StatusCode = 400;
                            await context.Response.WriteAsync("Invalid input firstNumber \n");
                        }
                    }
                    else
                    {
                        if (context.Response.StatusCode == 200)
                            context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid input firstNumber \n");
                    }


                    if (context.Request.Query.ContainsKey("secondNumber"))
                    {
                        string secondNumberString = context.Request.Query["secondNumber"][0];
                        if (!string.IsNullOrEmpty(secondNumberString))
                        {
                            secondNumber = int.Parse(secondNumberString);
                        }
                        else
                        {
                            if (context.Response.StatusCode == 200)
                                context.Response.StatusCode = 400;
                            await context.Response.WriteAsync("Invalid Input secondNumber \n");
                        }
                    }
                    else
                    {
                        if (context.Response.StatusCode == 200)
                            context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid Input secondNumber \n");
                    }

                    if (context.Request.Query.ContainsKey("operation"))
                    {
                        operation = Convert.ToString(context.Request.Query["operation"][0]);

                        switch (operation)
                        {
                            case "add": result = firstNumber + secondNumber; break;
                            case "subtract": result = firstNumber - secondNumber; break;
                            case "multiply": result = firstNumber * secondNumber; break;
                            case "divide": result = (secondNumber != 0) ? firstNumber / secondNumber : 0; break;
                            case "mod": result = (secondNumber != 0) ? firstNumber % secondNumber : 0; break;
                        }

                        if (result.HasValue)
                        {
                            await context.Response.WriteAsync("Result: " + result);
                        }
                        else
                        {
                            if (context.Response.StatusCode == 200)
                                context.Response.StatusCode = 400;
                            await context.Response.WriteAsync("Invalid operaton");
                        }
                    }
                    else
                    {
                        if (context.Response.StatusCode == 200)
                            context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid operaton");

                    }
                }

            });
            app.Run();
        }
    }
}