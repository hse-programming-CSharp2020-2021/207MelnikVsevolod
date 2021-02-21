using System;
using System.Collections.Generic;

namespace Project
{
    public interface IAssignable
    {
        List<User> Users { get; }

        void Assign(User user);
        void Remove(User user);
    }
}
