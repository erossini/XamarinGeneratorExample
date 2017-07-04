using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PSC.Xamarin.MvvmHelpers;
using MyExpenses.Enums;
using MyExpenses.EventsArgs;
using MyExpenses.Helpers;
using MyExpenses.Interfaces;
using MyExpenses.Models;
using MyExpenses.Repository;
using Plugin.Media;
using Xamarin.Forms;

namespace MyExpenses.ViewModels
{
    /// <summary>
    /// Class BaseGalleryImage.
    /// </summary>
    /// <seealso cref="PSC.Xamarin.MvvmHelpers.BaseViewModel" />
    public abstract class BaseGalleryImage : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseForViewModel" /> class.
        /// </summary>
        protected BaseGalleryImage()
        {
            this.ValidationErrors = new Dictionary<string, string>();
            InitMedia();
        }

        #region Model
        /// <summary>
        /// The identifier
        /// </summary>
        private int _id;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get {
                return _id;
            }

            set {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        /// <summary>
        /// Section image
        /// </summary>
        public SectionImage Section
        {
            get {
                return _section;
            }
            set {
                if (_section != value)
                {
                    _section = value;
                    OnPropertyChanged("Section");
                }
            }
        }
        private SectionImage _section;
        #endregion
        #region Show content or not
        /// <summary>
        /// The show empty
        /// </summary>
        private bool _showEmpty;

        /// <summary>
        /// The show content
        /// </summary>
        private bool _showContent;

        /// <summary>
        /// Gets or sets a value indicating to show a message for empty list
        /// </summary>
        /// <value><c>true</c> if it shows a message for empty list; otherwise, <c>false</c>.</value>
        public bool ShowEmpty
        {
            get {
                return _showEmpty;
            }
            set {
                if (_showEmpty != value)
                {
                    _showEmpty = value;
                    OnPropertyChanged("ShowEmpty");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating to show page details
        /// </summary>
        /// <value><c>true</c> if it shows details for a page; otherwise, <c>false</c>.</value>
        public bool ShowContent
        {
            get {
                return _showContent;
            }
            set {
                if (_showContent != value)
                {
                    _showContent = value;
                    OnPropertyChanged("ShowContent");
                }
            }
        }
        #endregion
        #region Images
        /// <summary>
        /// Loads the images.
        /// </summary>
        /// <param name="Section">The section.</param>
        public async void LoadImages(SectionImage Section, int ItemId)
        {
            IsBusy = true;

            List<GalleryImage> list = await FileHelper.LoadImages(Section, ItemId);
            foreach (GalleryImage imageGallery in list)
            {
                Images.Add(imageGallery);
                OnPropertyChanged("Images");
            }

            if (Images.Count == 0)
            {
                ShowEmpty = true;
                ShowContent = false;
            }
            else
            {
                ShowEmpty = false;
                ShowContent = true;
            }

            IsBusy = false;
        }
        #endregion
        #region Validation 
        #region Errors
        /// <summary>
        /// Gets or sets the error description.
        /// </summary>
        /// <value>The error description.</value>
        public string ErrorDescription
        {
            get {
                return _errorDescription;
            }
            set {
                if (_errorDescription != value)
                {
                    _errorDescription = value;
                    OnPropertyChanged("ErrorDescription");
                }
            }
        }
        private string _errorDescription;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:MyExpenses.ViewModels.BaseGalleryImage"/> show errors.
        /// </summary>
        /// <value><c>true</c> if show errors; otherwise, <c>false</c>.</value>
        public bool ShowErrors
        {
            get {
                return _showErrors;
            }
            set {
                if (_showErrors != value)
                {
                    _showErrors = value;
                    OnPropertyChanged("ShowErrors");

                    ErrorDescription = "";
                    if (this.ValidationErrors.Count > 0)
                    {
                        ErrorDescription = "I can't save! There are some errors in the form:";
                        foreach (KeyValuePair<string, string> s in this.ValidationErrors)
                        {
                            if (!string.IsNullOrEmpty(ErrorDescription))
                                ErrorDescription += "\r";
                            ErrorDescription += "  - " + s.Value.Trim();
                        }
                    }
                }
            }
        }
        private bool _showErrors = false;
        #endregion

        /// <summary>
        /// Gets or sets the validation errors.
        /// </summary>
        /// <value>The validation errors.</value>
        public Dictionary<string, string> ValidationErrors { get; set; }

        /// <summary>
        /// Returns true if there is not error is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public bool IsValid
        {
            get {
                return this.ValidationErrors.Count < 1;
            }
            private set {
                IsValid = value;
            }
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        public void Validate()
        {
            this.ValidationErrors.Clear();
            this.ValidateSelf();
            this.OnPropertyChanged("IsValid");
            this.OnPropertyChanged("ValidationErrors");
        }

        /// <summary>
        /// Validates
        /// </summary>
        protected abstract void ValidateSelf();
        #endregion
        #region Events
        /// <summary>
        /// Form error handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FormErrorEventArgs"/> instance containing the event data.</param>
        public delegate void FormErrorHandler(object sender, FormErrorEventArgs e);

        /// <summary>
        /// Occurs when {form error}.
        /// </summary>
        public event FormErrorHandler FormError;

        /// <summary>
        /// Save handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SaveEventArgs"/> instance containing the event data.</param>
        public delegate void SaveHandler(object sender, SaveEventArgs e);

        /// <summary>
        /// Occurs when {form save}.
        /// </summary>
        public event SaveHandler FormSave;

        /// <summary>
        /// Form error handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FormSaveErrorEventArgs"/> instance containing the event data.</param>
        public delegate void FormSaveErrorHandler(object sender, FormSaveErrorEventArgs e);

        /// <summary>
        /// Occurs when on form error.
        /// </summary>
        public event FormSaveErrorHandler FormSaveError;

        /// <summary>
        /// Form error handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ParamErrorEventArgs"/> instance containing the event data.</param>
        public delegate void ParamErrorHandler(object sender, ParamErrorEventArgs e);

        /// <summary>
        /// Occurs when parameter error
        /// </summary>
        public event ParamErrorHandler ParamError;

        /// <summary>
        /// Handles the <see cref="E:FormError" /> event.
        /// </summary>
        /// <param name="e">The <see cref="FormErrorEventArgs" /> instance containing the event data.</param>
        protected virtual void OnFormError(FormErrorEventArgs e)
        {
            this.FormError?.Invoke(this, e);
        }

        /// <summary>
        /// Handles the <see cref="E:FormSaveError" /> event.
        /// </summary>
        /// <param name="e">The <see cref="FormSaveErrorEventArgs" /> instance containing the event data.</param>
        protected virtual void OnFormSaveError(FormSaveErrorEventArgs e)
        {
            this.FormSaveError?.Invoke(this, e);
        }

        /// <summary>
        /// Handles the <see cref="E:ParamError" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ParamErrorEventArgs" /> instance containing the event data.</param>
        protected virtual void OnParamError(ParamErrorEventArgs e)
        {
            this.ParamError?.Invoke(this, e);
        }

        /// <summary>
        /// Handles the <see cref="E:FormSave" /> event.
        /// </summary>
        /// <param name="e">The <see cref="SaveEventArgs" /> instance containing the event data.</param>
        protected virtual void OnFormSave(SaveEventArgs e)
        {
            this.FormSave?.Invoke(this, e);
        }
        #endregion
        #region Managing Images
        /// <summary>
        /// The initialized
        /// </summary>
        private bool initialized = false;
        /// <summary>
        /// The camera command
        /// </summary>
        public ICommand _cameraCommand = null;
        /// <summary>
        /// The delete command
        /// </summary>
        public ICommand _deleteCommand = null;
        /// <summary>
        /// The pick command
        /// </summary>
        public ICommand _pickCommand = null;
        /// <summary>
        /// The preview image command
        /// </summary>
        public ICommand _previewImageCommand = null;
        /// <summary>
        /// The save command
        /// </summary>
        public ICommand _saveCommand = null;
        /// <summary>
        /// The preview image
        /// </summary>
        public ImageSource _previewImage = null;
        /// <summary>
        /// The images
        /// </summary>
        private ObservableCollection<GalleryImage> _images = new ObservableCollection<GalleryImage>();

        /// <summary>
        /// Gets or sets the is loading.
        /// </summary>
        /// <value>The is loading.</value>
        public bool IsLoading { get; set; }

        /// <summary>
        /// The show delete
        /// </summary>
        private bool _showDelete = false;
        /// <summary>
        /// Gets or sets a value indicating whether it's possible to show delete button.
        /// </summary>
        /// <value><c>true</c> if {show delete}; otherwise, <c>false</c>.</value>
        public bool ShowDelete
        {
            get {
                return _showDelete;
            }
            set {
                if (_showDelete != value)
                {
                    _showDelete = value;
                    OnPropertyChanged("ShowDelete");
                }
            }
        }

        /// <summary>
        /// Gets or sets the preview identifier.
        /// </summary>
        /// <value>The preview identifier.</value>
        public Guid PreviewId { get; set; }

        #region Gallery Images

        /// <summary>
        /// Gets the images.
        /// </summary>
        /// <value>The images.</value>
        public ObservableCollection<GalleryImage> Images
        {
            get { return _images; }
        }

        /// <summary>
        /// Gets or sets the preview image.
        /// </summary>
        /// <value>The preview image.</value>
        public ImageSource PreviewImage
        {
            get { return _previewImage; }
            set {
                SetProperty(ref _previewImage, value);
            }
        }

        /// <summary>
        /// Gets the camera command.
        /// </summary>
        /// <value>The camera command.</value>
        public ICommand CameraCommand
        {
            get { return _cameraCommand ?? new Command(async () => await ExecuteCameraCommand(), () => CanExecuteCameraCommand()); }
        }

        /// <summary>
        /// Determines whether this instance can execute camera command.
        /// </summary>
        /// <returns><c>true</c> if this instance can execute camera command; otherwise, <c>false</c>.</returns>
        public bool CanExecuteCameraCommand()
        {
            if (!initialized)
                InitMedia();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Executes the camera command.
        /// </summary>
        /// <returns>The camera command.</returns>
        public async Task ExecuteCameraCommand()
        {
            if (!initialized)
                InitMedia();

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());

            if (file == null)
                return;

            byte[] imageAsBytes = null;
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                imageAsBytes = memoryStream.ToArray();

                if (imageAsBytes.Length == 0)
                {
                    imageAsBytes = await FileHelper.GetImageAsByte(file.Path);
                }
                file.Dispose();
            }

            if (imageAsBytes.Length > 0)
            {
                var resizer = DependencyService.Get<IImageResize>();
                imageAsBytes = resizer.ResizeImage(imageAsBytes, 1080, 1080);

                var imageSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
                _images.Add(new GalleryImage { Source = imageSource, OrgImage = imageAsBytes, ImageSize = imageAsBytes.Length });
            }
        }

        /// <summary>
        /// Initializes the media.
        /// </summary>
        public async void InitMedia()
        {
            await CrossMedia.Current.Initialize();
            initialized = true;
            ((Command)CameraCommand).ChangeCanExecute();
            ((Command)PickCommand).ChangeCanExecute();
        }

        /// <summary>
        /// Gets the camera command.
        /// </summary>
        /// <value>The camera command.</value>
        public ICommand PickCommand
        {
            get { return _pickCommand ?? new Command(async () => await ExecutePickCommand(), () => CanExecutePickCommand()); }
        }

        /// <summary>
        /// Determines whether this instance can execute camera command.
        /// </summary>
        /// <returns><c>true</c> if this instance can execute camera command; otherwise, <c>false</c>.</returns>
        public bool CanExecutePickCommand()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Executes the camera command.
        /// </summary>
        /// <returns>The camera command.</returns>
        public async Task ExecutePickCommand()
        {
            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            byte[] imageAsBytes = null;
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                imageAsBytes = memoryStream.ToArray();
            }

            if (imageAsBytes.Length > 0)
            {
                var resizer = DependencyService.Get<IImageResize>();
                imageAsBytes = resizer.ResizeImage(imageAsBytes, 1080, 1080);

                var imageSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
                _images.Add(new GalleryImage { Source = imageSource, OrgImage = imageAsBytes });
            }
        }

        /// <summary>
        /// Gets the preview image command.
        /// </summary>
        /// <value>The preview image command.</value>
        public ICommand PreviewImageCommand
        {
            get {
                return _previewImageCommand ?? new Command<Guid>((img) =>
                {
                    if (_images.Count > 0)
                    {
                        var image = _images.Single(x => x.ImageId == img).OrgImage;
                        if (image.Length > 0)
                        {
                            IsBusy = true;
                            PreviewId = img;
                            PreviewImage = ImageSource.FromStream(() => new MemoryStream(image));
                            ShowDelete = true;
                            IsBusy = false;
                        }
                    }
                });
            }
        }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        /// <value>The delete command.</value>
        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? new Command(() => ExecuteDeleteCommand()); }
        }

        /// <summary>
        /// Executes the delete command.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task ExecuteDeleteCommand()
        {
            IsBusy = true;
            foreach (GalleryImage g in _images)
            {
                if (g.ImageId == PreviewId)
                {
                    // remove file from file system
                    FileHelper.DeleteImage(g.ImageId.ToString(), Section);

                    // remove file from database
                    if (g.Id != 0)
                    {
                        MyExpensesRepository repo = new MyExpensesRepository();
                        repo.DeleteImages(g.Id);
                    }

                    // remove the image from the observable collection
                    _images.Remove(g);

                    PreviewId = Guid.Empty;
                    PreviewImage = null;
                    ShowDelete = false;

                    OnPropertyChanged("Images");
                    OnPropertyChanged("ShowDelete");
                }
            }
            IsBusy = false;
        }
        #endregion
        #endregion
        #region Save images
        /// <summary>
        /// Saves the gallery on file system
        /// </summary>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        public async void SaveGallery()
        {
            if (Images.Count > 0)
            {
                if (Section == 0)
                {
                    Debug.WriteLine("SaveGallery: Section = 0");
                    throw new NotImplementedException();
                }
                await FileHelper.SaveGalleryImages(Images.ToList(), Section, Id);
            }
        }
        #endregion
    }
}