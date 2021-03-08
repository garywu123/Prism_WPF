#region License
// author:         吴经纬
// created:        10:43
// description:
#endregion

using Prism.Commands;

namespace PrismDemo.Core.Commands
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveAllCommand { get; }
    }

    /// <summary>
    ///     The commands activity of the application level
    /// </summary>
    public class ApplicationCommands : IApplicationCommands
    {
        /// <summary>
        ///     Save all Commands
        /// </summary>
        public CompositeCommand SaveAllCommand { get; } = new CompositeCommand();
    }
}
