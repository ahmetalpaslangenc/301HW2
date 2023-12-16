using CetContact.Model;

namespace CetContact.Views;

public partial class AddContactPage : ContentPage
{
    ContactRepository contactRepository;
	public AddContactPage()
	{
		InitializeComponent();
        contactRepository = new ContactRepository();
	}

    private void BackButton_Clicked(object sender, EventArgs e)
    {
		//Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
        //Shell.Current.GoToAsync("//"+nameof(ContactsPage));
       
        Shell.Current.GoToAsync("..");

    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
	if (string.IsNullOrEmpty(NameEntry.Text) string.IsNullEmpty(EmailEntry.Text))
 	{
  		if (string.IsNullOrEmpty(NameEntry.Text)) popUpLayoutName.IsVisible = true;
    		else popUpLayoutName.IsVisible = false;
      		if (string.IsNullOrEmpty(EmailEntry.Text)) popUpLayoutEmail.IsVisible = true;
		else popUpLayoutEmail.IsVisible = false;
  		return;
	}
    
        ContactInfo contact = new ContactInfo
        {
            Name = NameEntry.Text,
            Phone = PhoneEntry.Text,
            Address = AdressEntry.Text,
            Email = EmailEntry.Text,
        };
        await contactRepository.AddContact(contact);
        await Shell.Current.GoToAsync("..");
    }
}
