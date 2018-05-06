using System.Windows.Controls;
namespace Indigo
{
    #region HasTextProperty
    /// <summary>
    /// The hastext attached property for <see cref="ListBox"/>
    /// </summary>
    public class HasTextProperty:BaseAttachedProperty<HasTextProperty,bool> 
    {
        //public override void OnValueChanged(System.Windows.DependencyObject sender, System.Windows.DependencyPropertyChangedEventArgs e)
        //{
        //    //var listBox = sender as ListBox;
        //    //if (listBox == null)
        //    //    return;
        //    //listBox.ItemsSource = (bool)e.NewValue ? MusicItemViewModel.Instance.SearchedItems : MusicItemViewModel.Instance.Items;
        //}
    }
    #endregion
}
