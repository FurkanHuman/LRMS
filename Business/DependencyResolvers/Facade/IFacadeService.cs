using Business.Abstract;

namespace Business.DependencyResolvers.Facade
{
    public interface IFacadeService
    {
        IAcademicJournalService AcademicJournalService();

        IAddressService AddressService();

        IAudioRecordService AudioRecordService();

        IBookService BookService();

        IBookSeriesService BookSeriesService();

        IBranchService BranchService();

        ICartographicMaterialService CartographicMaterialService();

        ICategoryService CategoryService();

        ICityService CityService();

        ICommunicationService CommunicationService();

        IComposerService ComposerService();

        IConsultantService ConsultantService();

        ICounterService CounterService();

        ICountryService CountryService();

        ICoverCapService CoverCapService();

        IDepictionService DepictionService();

        IDimensionService DimensionService();

        IDirectorService DirectorService();

        IDissertationService DissertationService();

        IEditionService EditionService();

        IEditorService EditorService();

        IElectronicsResourceService ElectronicsResourceService();

        IEMaterialFileService EMaterialFileService();

        IEncyclopediaService EncyclopediaService();

        IGraphicalImageService GraphicalImageService();

        IGraphicDesignerService GraphicDesignerService();

        IGraphicDirectorService GraphicDirectorService();

        IImageService ImageService();

        IInterpretersService InterpretersService();

        IKitService KitService();

        ILanguageService LanguageService();

        ILibraryService LibraryService();

        IMagazineService MagazineService();

        IMicroformService MicroformService();

        IMusicalNoteService MusicalNoteService();

        INewsPaperService NewsPaperService();

        IObject3DService Object3DService();

        IOtherPeopleService OtherPeopleService();

        IPaintingService PaintingService();

        IPosterService PosterService();

        IPublisherService PublisherService();

        IRedactionService RedactionService();

        IReferenceService ReferenceService();

        IResearcherService ResearcherService();

        IStockService StockService();

        ITechnicalNumberService TechnicalNumberService();

        ITechnicalPlaceholderService TechnicalPlaceholderService();

        IThesisService ThesisService();

        IUniversityService UniversityService();

        IWriterService WriterService();
    }
}
