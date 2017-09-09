using Topshelf;
using log4net.Config;

namespace ConsumerService
{
    public class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>                                 //1
            {
                XmlConfigurator.Configure();
                x.UseLog4Net();
                x.Service<ServiceHost>(s =>                        //2
                {
                    s.ConstructUsing(name => new ServiceHost());     //3
                    s.WhenStarted(tc => tc.Start());              //4
                    s.WhenStopped(tc => tc.Stop());
                    //5
                });
                x.RunAsLocalSystem();                            //6

                x.SetDescription("A simple service to play around with RabbitMQ Consumers");        //7
                x.SetDisplayName("My RabbitMQ Consumer");                       //8
                x.SetServiceName("MyRabbitMQConsumer");                       //9
            });                                                  //10
        }
    }
}
