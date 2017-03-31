// <copyright company="Benjamin Abt (  http://benjamin-abt.com - http://schwabencode.com  )">
//    Copyright (c) 2016 All Rights Reserved
// </copyright>
// <project>FlexMapper</project>
// <author>Benjamin Abt</author>
// <date>July 18, 2016</date>

using System.Collections.Generic;
using System.Linq;

namespace SchwabenCode.FlexMapper
{
    /// <summary>
    /// Abstract base implemention of flex mapper.
    /// </summary>
    /// <typeparam name="T1">Type #1</typeparam>
    /// <typeparam name="T2">Type #2</typeparam>
    public abstract class FlexMapper<T1, T2> : FlexMappeCore, IFlexMapper<T1, T2>
        // Both types have to be a class
        where T1 : class, new()
        where T2 : class, new()
    {
        #region Map In/Out

        /// <summary>
        /// Maps <paramref name="t1"/> to <paramref name="t2"/>
        /// </summary>
        /// <param name="t1">Source object of <typeparamref name="T1"/></param>
        /// <param name="t2">Target object of <typeparamref name="T2"/></param>
        /// <return>Returns <paramref name="t2"/> will values of <paramref name="t1"/>.</return>
        public abstract T2 Map( T1 t1, T2 t2 );

        /// <summary>
        /// Maps <paramref name="t1"/> to <paramref name="t2"/>
        /// </summary>
        /// <param name="t1">Source object of <typeparamref name="T2"/></param>
        /// <param name="t2">Target object of <typeparamref name="T1"/></param>
        /// <return>Returns <paramref name="t1"/> will values of <paramref name="t1"/>.</return>
        public abstract T1 Map( T2 t1, T1 t2 );

        #endregion Map In/Out

        #region Map Out

        /// <summary>
        /// Maps an <paramref name="t1"/> object to an <typeparamref name="T2"/> object.
        /// </summary>
        /// <return>Returns a new object of <typeparamref name="T2"/> with the values of <paramref name="t1"/>.</return>
        public virtual T2 Map( T1 t1 )
        {
            return Map( t1, new T2() );
        }

        /// <summary>
        /// Maps an <paramref name="t2"/> object to an <typeparamref name="T1"/> object.
        /// </summary>
        /// <return>Returns a new object of <typeparamref name="T1"/> with the values of <paramref name="t2"/>.</return>
        public virtual T1 Map( T2 t2 )
        {
            return Map( t2, new T1() );
        }

        #endregion Map Out

        #region Map IEnumerable

        /// <summary>
        /// Maps an <see cref="IQueryable"/> collection of <typeparamref name="T2"/>.
        /// </summary>
        /// <return>Returns an enumerable with new objects with the value of <paramref name="t1"/>.</return>
        public virtual IEnumerable<T2> Map( IEnumerable<T1> t1 )
        {
            return t1.Select( Map );
        }

        /// <summary>
        /// Maps an enumerable of <paramref name="t2"/> to an enumerable of <typeparamref name="T1"/>.
        /// </summary>
        /// <return>Returns an enumerable of <typeparamref name="T1"/>.</return>
        public virtual IEnumerable<T1> Map( IEnumerable<T2> t2 )
        {
            return t2.Select( Map );
        }

        #endregion Map IEnumerable

        #region Map IList

        /// <summary>
        /// Maps an <see cref="IList{T}"/> collection of <typeparamref name="T2"/>.
        /// </summary>
        /// <return>Returns a <see cref="IList{T}"/> collection of <typeparamref name="T2"/> with the value of <paramref name="t1"/>.</return>
        public virtual IList<T2> Map( IList<T1> t1 )
        {
            return Map( t1.AsEnumerable() ).ToList();
        }

        /// <summary>
        /// Maps an <see cref="IList{T}"/> collection of <typeparamref name="T1"/>.
        /// </summary>
        /// <return>Returns a <see cref="IList{T}"/> collection of <typeparamref name="T1"/> with the value of <paramref name="t2"/>.</return>
        public virtual IList<T1> Map( IList<T2> t2 )
        {
            return Map( t2.AsEnumerable() ).ToList();
        }

        #endregion Map IList

        #region Map ICollection

        /// <summary>
        /// Maps an <see cref="ICollection{T}"/> collection of <typeparamref name="T2"/>.
        /// </summary>
        /// <return>Returns a <see cref="ICollection{T}"/> collection of <typeparamref name="T2"/> with the value of <paramref name="t1"/>.</return>
        public virtual ICollection<T2> Map( ICollection<T1> t1 )
        {
            return Map( t1.AsEnumerable() ).ToList();
        }

        /// <summary>
        /// Maps an <see cref="ICollection{T}"/> collection of <typeparamref name="T1"/>.
        /// </summary>
        /// <return>Returns a <see cref="ICollection{T}"/> collection of <typeparamref name="T1"/> with the value of <paramref name="t2"/>.</return>
        public virtual ICollection<T1> Map( ICollection<T2> t2 )
        {
            return Map( t2.AsEnumerable() ).ToList();
        }

        #endregion Map ICollection

        #region Map IReadOnlyCollection

        /// <summary>
        /// Maps an <see cref="IReadOnlyCollection{T}"/> collection of <typeparamref name="T2"/>.
        /// </summary>
        /// <return>Returns a <see cref="IReadOnlyCollection{T}"/> collection of <typeparamref name="T2"/> with the value of <paramref name="t1"/>.</return>
        public virtual IReadOnlyCollection<T2> Map( IReadOnlyCollection<T1> t1 )
        {
            return Map( t1.AsEnumerable() ).ToList();
        }

        /// <summary>
        /// Maps an <see cref="IReadOnlyCollection{T}"/> collection of <typeparamref name="T1"/>.
        /// </summary>
        /// <return>Returns a <see cref="IReadOnlyCollection{T}"/> collection of <typeparamref name="T1"/> with the value of <paramref name="t2"/>.</return>
        public virtual IReadOnlyCollection<T1> Map( IReadOnlyCollection<T2> t2 )
        {
            return Map( t2.AsEnumerable() ).ToList();
        }

        #endregion Map IReadOnlyCollection
    }

}
