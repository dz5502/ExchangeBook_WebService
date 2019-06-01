using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


/// <summary>
/// WebMethod特性
/// 
/// 
/// （1）BufferResponse 属性
///    该属性表明是否启用对Web Service方法响应的缓冲。当设置为true时，Web Service方法将响应序列化到内存缓冲区中，
///    直到缓存区被用满或者响应结束后，响应才会被发送给客户端。相反，设置为false时，.NET默认以16KB的块区缓冲响应，
///    响应在被序列化的同时将会被不断发送给客户端，无论该响应是否已经完全结束。
///    (PS：默认BufferResponse被设置为true。当Web Service要发送大量数据流给客户端时，
///    设置BufferResponse为false时可以防止大规模数据一次性刷新到内存，而对于小量数据，设置为true则可以有效地提高性能。)
///    
/// (2）EnableSession 属性 
/// 　　该属性指定是否启用会话状态。如果为true，则启用，为fasle则禁用。默认被设置为false。
/// 　　[WebMethod(EnableSession=true)]

/// 　　
/// （3）CacheDuration 属性
///     该属性指示启用对Web Service方法结果的缓存。服务端将会缓存每个唯一参数集的结果，
///     该属性的值指定服务器端应该对结果进行多少秒的缓存处理。如果该值为0，则禁用对结果进行缓存；
///     如果不为零，则启用缓存，单位为秒，意为设置多少秒的缓存时间。默认该值被设为0。
///     (WithCache方法设置了10秒的缓存时间，即10秒内的访问都会得到一样的结果。)
///     
/// （4）Description属性
///　　该属性很简单，提供了对某个Web Service方法的说明，并且会显示在服务帮助页上面。
///　　[WebMethod(Description="方法:Hello World") ]

/// 
/// （5）MessageName 属性
///     该属性是Web Service能够唯一确定使用别名的重载方法。除非另外指定，默认值是方法名称。
///     当指定MessageName时，结果SOAP消息将反映该名称，而不是实际的方法名称。
///     当Web Service提供了两个同名的方法时，MessageName属性会很有用，这一点将会体现在WSDL中：
///         [WebMethod(MessageName="Add2")]

///     
///（6）TransactionOption   属性
/// 　　该属性用以设置Web Service方法的事务特性，在.NET中事务模型是基于声明性的，而不是编写特定的代码来处理提交和回滚事务。
/// 　　在Web Service中，可以通过TransactionOption属性来设置该方法是否需要被放入一个事务之中。
/// 　　如果申明了事务属性，执行Web Service方法时引发异常会自动终止事务，相反如果未发生任何异常，则自动提交事务。
/// 　　事务最常用的一个场景就是数据库访问，所以该属性在利用Web Service实现的分布式数据库访问中就特别有用。    \
/// 　　
/// 　　设置TransactionOption.Required、TransactionOption.RequiresNew表示创建一个新的事务。
/// 　　意思是说当TransactionOption的属性为Required或 RequiresNew的WEB服务方法
/// 　　调用另一个TransactionOption的属性为Required或RequiresNew的WEB服务方法时，
/// 　　每个WEB服务方法将参与他们自己的事务，因为Web Service方法只能用作事务中的根对象。
////    PS：WEB服务方法的TransactionOption默认属性为Disabled

////    提交事务ContextUtil.SetComplete();

////    回滚事务ContextUtil.SetAbort();

 

////    [WebMethod(TransactionOption = TransactionOption.Required)]
////    public string HelloWorld()
////    {
////        try
////        {
////            SqlConnection con = new SqlConnection("server=.;uid=sa;pwd=sa;database=db.mdf;");
////            SqlCommand cmd = new SqlCommand("update users set name = 'yangxing' where id = 5", con);
////            con.Open();
////            cmd.ExecuteNonQuery();
////            cmd.CommandText = "update users1 set name = 'yangxing1' where id = 6";//users1表不存在，执行该语句报错
////            cmd.ExecuteNonQuery();//抛出异常
////            ContextUtil.SetComplete();//提交事务
////            return "true";
////        }
////        catch
////        {
////            ContextUtil.SetAbort();//回滚事务
////            return "false";
////        }
////    }
/// 
/// 
/// </summary>

namespace ExchangeBook_WebService
{
    /// <summary>
    /// ExchangeBook 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class ExchangeBook : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
