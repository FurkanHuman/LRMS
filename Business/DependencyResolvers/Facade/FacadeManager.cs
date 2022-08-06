using Business.Abstract;

namespace Business.DependencyResolvers.Facade
{
    public class FacadeManager : IFacadeService
    {
        private readonly IAcademicJournalService _academicJournalService;
        private readonly IAddressService _addressService;
        private readonly IAudioRecordService _audioRecordService;
        private readonly IBookService _bookService;
        private readonly IBookSeriesService _bookSeriesService;
        private readonly IBranchService _branchService;
        private readonly ICartographicMaterialService _cartographicMaterialService;
        private readonly ICategoryService _categoryService;
        private readonly ICityService _cityService;
        private readonly ICommunicationService _communicationService;
        private readonly IComposerService _composerService;
        private readonly IConsultantService _consultantService;
        private readonly ICounterService _counterService;
        private readonly ICountryService _countryService;
        private readonly ICoverCapService _coverCapService;
        private readonly IDepictionService _depictionService;
        private readonly IDimensionService _dimensionService;
        private readonly IDirectorService _directorService;
        private readonly IDissertationService _dissertationService;
        private readonly IEditionService _editionService;
        private readonly IEditorService _editorService;
        private readonly IElectronicsResourceService _electronicsResourceService;
        private readonly IEMaterialFileService _eMaterialFileService;
        private readonly IEncyclopediaService _encyclopediaService;
        private readonly IGraphicalImageService _graphicalImageService;
        private readonly IGraphicDesignerService _graphicDesignerService;
        private readonly IGraphicDirectorService _graphicDirectorService;
        private readonly IImageService _imageService;
        private readonly IInterpretersService _interpretersService;
        private readonly IKitService _kitService;
        private readonly ILanguageService _languageService;
        private readonly ILibraryService _libraryService;
        private readonly IMagazineService _magazineService;
        private readonly IMicroformService _microformService;
        private readonly IMusicalNoteService _musicalNoteService;
        private readonly INewsPaperService _newsPaperService;
        private readonly IObject3DService _object3DService;
        private readonly IOtherPeopleService _otherPeopleService;
        private readonly IPaintingService _paintingService;
        private readonly IPosterService _posterService;
        private readonly IPublisherService _publisherService;
        private readonly IRedactionService _redactionService;
        private readonly IReferenceService _referenceService;
        private readonly IResearcherService _researcherService;
        private readonly IStockService _stockService;
        private readonly ITechnicalNumberService _technicalNumberService;
        private readonly ITechnicalPlaceholderService _technicalPlaceholderService;
        private readonly IThesisService _thesisService;
        private readonly IUniversityService _universityService;
        private readonly IWriterService _writerService;



        public FacadeManager(IAcademicJournalService academicJournalService,
                             IAddressService addressService,
                             IAudioRecordService audioRecordService,
                             IBookService bookService,
                             IBookSeriesService bookSeriesService,
                             IBranchService branchService,
                             ICartographicMaterialService cartographicMaterialService,
                             ICategoryService categoryService,
                             ICityService cityService,
                             ICommunicationService communicationService,
                             IComposerService composerService,
                             IConsultantService consultantService,
                             ICounterService counterService,
                             ICountryService countryService,
                             ICoverCapService coverCapService,
                             IDepictionService depictionService,
                             IDimensionService dimensionService,
                             IDirectorService directorService,
                             IDissertationService dissertationService,
                             IEditionService editionService,
                             IEditorService editorService,
                             IElectronicsResourceService electronicsResourceService,
                             IEMaterialFileService eMaterialFileService,
                             IEncyclopediaService encyclopediaService,
                             IGraphicalImageService graphicalImageService,
                             IGraphicDesignerService graphicDesignerService,
                             IGraphicDirectorService graphicDirectorService,
                             IImageService imageService,
                             IInterpretersService interpretersService,
                             IKitService kitService,
                             ILanguageService languageService,
                             ILibraryService libraryService,
                             IMagazineService magazineService,
                             IMicroformService microformService,
                             IMusicalNoteService musicalNoteService,
                             INewsPaperService newsPaperService,
                             IObject3DService object3DService,
                             IOtherPeopleService otherPeopleService,
                             IPaintingService paintingService,
                             IPosterService posterService,
                             IPublisherService publisherService,
                             IRedactionService redactionService,
                             IReferenceService referenceService,
                             IResearcherService researcherService,
                             IStockService stockService,
                             ITechnicalNumberService technicalNumberService,
                             ITechnicalPlaceholderService technicalPlaceholderService,
                             IThesisService thesisService,
                             IUniversityService universityService,
                             IWriterService writerService)
        {
            _academicJournalService = academicJournalService;
            _addressService = addressService;
            _audioRecordService = audioRecordService;
            _bookService = bookService;
            _bookSeriesService = bookSeriesService;
            _branchService = branchService;
            _cartographicMaterialService = cartographicMaterialService;
            _categoryService = categoryService;
            _cityService = cityService;
            _communicationService = communicationService;
            _composerService = composerService;
            _consultantService = consultantService;
            _counterService = counterService;
            _countryService = countryService;
            _coverCapService = coverCapService;
            _depictionService = depictionService;
            _dimensionService = dimensionService;
            _directorService = directorService;
            _dissertationService = dissertationService;
            _editionService = editionService;
            _editorService = editorService;
            _electronicsResourceService = electronicsResourceService;
            _eMaterialFileService = eMaterialFileService;
            _encyclopediaService = encyclopediaService;
            _graphicalImageService = graphicalImageService;
            _graphicDesignerService = graphicDesignerService;
            _graphicDirectorService = graphicDirectorService;
            _imageService = imageService;
            _interpretersService = interpretersService;
            _kitService = kitService;
            _languageService = languageService;
            _libraryService = libraryService;
            _magazineService = magazineService;
            _microformService = microformService;
            _musicalNoteService = musicalNoteService;
            _newsPaperService = newsPaperService;
            _object3DService = object3DService;
            _otherPeopleService = otherPeopleService;
            _paintingService = paintingService;
            _posterService = posterService;
            _publisherService = publisherService;
            _redactionService = redactionService;
            _referenceService = referenceService;
            _researcherService = researcherService;
            _stockService = stockService;
            _technicalNumberService = technicalNumberService;
            _technicalPlaceholderService = technicalPlaceholderService;
            _thesisService = thesisService;
            _universityService = universityService;
            _writerService = writerService;
        }

        public IAcademicJournalService AcademicJournalService() => _academicJournalService;
        public IAddressService AddressService() => _addressService;
        public IAudioRecordService AudioRecordService() => _audioRecordService;
        public IBookSeriesService BookSeriesService() => _bookSeriesService;
        public IBookService BookService() => _bookService;
        public IBranchService BranchService() => _branchService;
        public ICartographicMaterialService CartographicMaterialService() => _cartographicMaterialService;
        public ICategoryService CategoryService() => _categoryService;
        public ICityService CityService() => _cityService;
        public ICommunicationService CommunicationService() => _communicationService;
        public IComposerService ComposerService() => _composerService;
        public IConsultantService ConsultantService() => _consultantService;
        public ICounterService CounterService() => _counterService;
        public ICountryService CountryService() => _countryService;
        public ICoverCapService CoverCapService() => _coverCapService;
        public IDepictionService DepictionService() => _depictionService;
        public IDimensionService DimensionService() => _dimensionService;
        public IDirectorService DirectorService() => _directorService;
        public IDissertationService DissertationService() => _dissertationService;
        public IEditionService EditionService() => _editionService;
        public IEditorService EditorService() => _editorService;
        public IElectronicsResourceService ElectronicsResourceService() => _electronicsResourceService;
        public IEMaterialFileService EMaterialFileService() => _eMaterialFileService;
        public IEncyclopediaService EncyclopediaService() => _encyclopediaService;
        public IGraphicalImageService GraphicalImageService() => _graphicalImageService;
        public IGraphicDesignerService GraphicDesignerService() => _graphicDesignerService;
        public IGraphicDirectorService GraphicDirectorService() => _graphicDirectorService;
        public IImageService ImageService() => _imageService;
        public IInterpretersService InterpretersService() => _interpretersService;
        public IKitService KitService() => _kitService;
        public ILanguageService LanguageService() => _languageService;
        public ILibraryService LibraryService() => _libraryService;
        public IMagazineService MagazineService() => _magazineService;
        public IMicroformService MicroformService() => _microformService;
        public IMusicalNoteService MusicalNoteService() => _musicalNoteService;
        public INewsPaperService NewsPaperService() => _newsPaperService;
        public IObject3DService Object3DService() => _object3DService;
        public IOtherPeopleService OtherPeopleService() => _otherPeopleService;
        public IPaintingService PaintingService() => _paintingService;
        public IPosterService PosterService() => _posterService;
        public IPublisherService PublisherService() => _publisherService;
        public IRedactionService RedactionService() => _redactionService;
        public IReferenceService ReferenceService() => _referenceService;
        public IResearcherService ResearcherService() => _researcherService;
        public IStockService StockService() => _stockService;
        public ITechnicalNumberService TechnicalNumberService() => _technicalNumberService;
        public ITechnicalPlaceholderService TechnicalPlaceholderService() => _technicalPlaceholderService;
        public IThesisService ThesisService() => _thesisService;
        public IUniversityService UniversityService() => _universityService;
        public IWriterService WriterService() => _writerService;
    }
}
