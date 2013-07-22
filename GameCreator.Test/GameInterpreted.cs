using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameCreator.Framework;
using GameCreator.Runtime.Game;
using GameCreator.Runtime;
using System.Reflection;

namespace GameCreator.Test
{
    [TestClass]
    public class GameInterpreted
    {
        [TestMethod]
        public void InstanceVars()
        {
            var context = LibraryContext.Current;

            Game.Init();

            var inst = new GameInstance(context.Resources);

            var dups = context.InstanceVariables.Intersect(context.BuiltInVariables).ToArray();

            Assert.IsFalse(dups.Any(), "Duplicate instance and global variable: {0}", string.Join(",", dups));

            foreach (var name in context.InstanceVariables)
            {
                Assert.IsNotNull(
                    inst.GetType().GetMember(
                        name,
                            MemberTypes.Property | MemberTypes.Field,
                            BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy).SingleOrDefault(),
                    "Instance variable {0} is not defined in the object!",
                    name
                );
            }

            // Todo: Filter by an attribute
            var members = inst.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
                .Where(m => (m.MemberType & (MemberTypes.Field | MemberTypes.Property)) != (MemberTypes)0
                && !m.GetCustomAttributes(typeof(NoGmlExportAttribute), false).Any());

            foreach (var m in members)
            {
                Assert.IsTrue(context.InstanceVariables.Any(v => v == m.Name), 
                    "Instance variable {0} not defined in LibraryContext or not marked with an attribute!", m.Name);
            }
        }
    }
}
