using System;
using System.Windows;
namespace Indigo
{
    /// <summary>
    /// Base Attached property
    /// </summary>
    /// <typeparam name="Parent">The parent class to an attached property</typeparam>
    /// <typeparam name="Property">Type of attached property</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent:BaseAttachedProperty<Parent,Property>,new()
    {

        #region Public events

        /// <summary>
        /// Fired when the value changed
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        #endregion

        #region Public properties

        /// <summary>
        /// Singleton instance of parent class  
        /// </summary>
        public static Parent Instance {get; private set;} 

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseAttachedProperty ()
	    {
            Instance = new Parent();
	    }
        #endregion

        #region Attached Property Definitions

        /// <summary>
        /// Attached property
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value",typeof(Property),typeof(BaseAttachedProperty<Parent, Property>),new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        /// <summary>
        /// Callback methed that called when <see cref="ValueProperty"/> changed
        /// </summary>
        /// <param name="d">Object that had its property changed</param>
        /// <param name="e">Dependency property event arguments</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //Instance.OnValueChanged(d, e);
            //Instance.ValueChanged(d, e);
        }

        /// <summary>
        /// Simple get function of property
        /// </summary>
        /// <param name="d">Element that owns that property</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) 
        {
            return (Property)d.GetValue(ValueProperty);
        }

        /// <summary>
        /// Simple set function of property
        /// </summary>
        /// <param name="d">Element that owns that property</param>
        /// <param name="value">Value to set</param>
        public static void SetValue(DependencyObject d, Property value)
        {
            d.SetValue(ValueProperty,value);
        }

        #endregion

        #region Event methods

        /// <summary>
        /// The method called when property of this type is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        #endregion

    }
}
