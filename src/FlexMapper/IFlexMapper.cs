// <copyright company="Benjamin Abt (  http://benjamin-abt.com - http://schwabencode.com  )">
//    Copyright (c) 2016 All Rights Reserved
// </copyright>
// <project>FlexMapper</project>
// <author>Benjamin Abt</author>
// <date>July 18, 2016</date>

using System.Collections.Generic;

namespace SchwabenCode.FlexMapper
{
    /// <summary>
    /// FlexMapper iterface
    /// </summary>
    /// <typeparam name="T1">Type #1</typeparam>
    /// <typeparam name="T2">Type #2</typeparam>
    public interface IFlexMapper<T1, T2>

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
        T2 Map( T1 t1, T2 t2 );

        /// <summary>
        /// Maps <paramref name="t1"/> to <paramref name="t2"/>
        /// </summary>
        /// <param name="t1">Source object of <typeparamref name="T2"/></param>
        /// <param name="t2">Target object of <typeparamref name="T1"/></param>
        /// <return>Returns <paramref name="t1"/> will values of <paramref name="t1"/>.</return>
        T1 Map( T2 t1, T1 t2 );

        #endregion Map In/Out

        #region Map Out

        /// <summary>
        /// Maps an <paramref name="t1"/> object to an <typeparamref name="T2"/> object.
        /// </summary>
        /// <return>Returns a new object of <typeparamref name="T2"/> with the values of <paramref name="t1"/>.</return>
        T2 Map( T1 t1 );

        /// <summary>
        /// Maps an <paramref name="t2"/> object to an <typeparamref name="T2"/> object.
        /// </summary>
        /// <return>Returns a new object of <typeparamref name="T1"/> with the values of <paramref name="t2"/>.</return>
        T1 Map( T2 t2 );

        #endregion Map Out

        #region Map IEnumerable

        /// <summary>
        /// Maps an <see cref="IEnumerable{T}"/> collection of <typeparamref name="T2"/>.
        /// </summary>
        /// <return>Returns a <see cref="IEnumerable{T}"/> collection of <typeparamref name="T2"/> with the value of <paramref name="t1"/>.</return>
        IEnumerable<T2> Map( IEnumerable<T1> t1 );

        /// <summary>
        /// Maps an <see cref="IEnumerable{T}"/> collection of <typeparamref name="T1"/>.
        /// </summary>
        /// <return>Returns a <see cref="IEnumerable{T}"/> collection of <typeparamref name="T1"/> with the value of <paramref name="t2"/>.</return>
        IEnumerable<T1> Map( IEnumerable<T2> t2 );

        #endregion Map IEnumerable

        #region Map IList

        /// <summary>
        /// Maps an <see cref="IList{T}"/> collection of <typeparamref name="T2"/>.
        /// </summary>
        /// <return>Returns a <see cref="IList{T}"/> collection of <typeparamref name="T2"/> with the value of <paramref name="t1"/>.</return>
        IList<T2> Map( IList<T1> t1 );

        /// <summary>
        /// Maps an <see cref="IList{T}"/> collection of <typeparamref name="T1"/>.
        /// </summary>
        /// <return>Returns a <see cref="IList{T}"/> collection of <typeparamref name="T1"/> with the value of <paramref name="t2"/>.</return>
        IList<T1> Map( IList<T2> t2 );

        #endregion Map IList

        #region Map ICollection

        /// <summary>
        /// Maps an <see cref="ICollection{T}"/> collection of <typeparamref name="T2"/>.
        /// </summary>
        /// <return>Returns a <see cref="ICollection{T}"/> collection of <typeparamref name="T2"/> with the value of <paramref name="t1"/>.</return>
        ICollection<T2> Map( ICollection<T1> t1 );

        /// <summary>
        /// Maps an <see cref="ICollection{T}"/> collection of <typeparamref name="T1"/>.
        /// </summary>
        /// <return>Returns a <see cref="ICollection{T}"/> collection of <typeparamref name="T1"/> with the value of <paramref name="t2"/>.</return>
        ICollection<T1> Map( ICollection<T2> t2 );

        #endregion Map ICollection

        #region Map IReadOnlyCollection

        /// <summary>
        /// Maps an <see cref="IReadOnlyCollection{T}"/> collection of <typeparamref name="T2"/>.
        /// </summary>
        /// <return>Returns a <see cref="IReadOnlyCollection{T}"/> collection of <typeparamref name="T2"/> with the value of <paramref name="t1"/>.</return>
        IReadOnlyCollection<T2> Map( IReadOnlyCollection<T1> t1 );

        /// <summary>
        /// Maps an <see cref="IReadOnlyCollection{T}"/> collection of <typeparamref name="T1"/>.
        /// </summary>
        /// <return>Returns a <see cref="IReadOnlyCollection{T}"/> collection of <typeparamref name="T1"/> with the value of <paramref name="t2"/>.</return>
        IReadOnlyCollection<T1> Map( IReadOnlyCollection<T2> t2 );

        #endregion Map IReadOnlyCollection
    }

}
