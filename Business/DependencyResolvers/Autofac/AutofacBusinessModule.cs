using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FacadeManager>().As<IFacadeService>().SingleInstance();

            builder.RegisterType<AcademicJournalManager>().As<IAcademicJournalService>().SingleInstance();
            builder.RegisterType<EfAcademicJournalDal>().As<IAcademicJournalDal>().SingleInstance();

            builder.RegisterType<AddressManager>().As<IAddressService>().SingleInstance();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>().SingleInstance();
            builder.RegisterType<AddressFacadeManager>().As<IAddressFacadeService>().SingleInstance();

            builder.RegisterType<AudioRecordManager>().As<IAudioRecordService>().SingleInstance();
            builder.RegisterType<EfAudioRecordDal>().As<IAudioRecordDal>().SingleInstance();

            builder.RegisterType<BookManager>().As<IBookService>().SingleInstance();
            builder.RegisterType<EfBookDal>().As<IBookDal>().SingleInstance();

            builder.RegisterType<BookSeriesManager>().As<IBookSeriesService>().SingleInstance();
            builder.RegisterType<EfBookSeriesDal>().As<IBookSeriesDal>().SingleInstance();

            builder.RegisterType<BranchManager>().As<IBranchService>().SingleInstance();
            builder.RegisterType<EfBranchDal>().As<IBranchDal>().SingleInstance();

            builder.RegisterType<CartographicMaterialManager>().As<ICartographicMaterialService>().SingleInstance();
            builder.RegisterType<EfCartographicMaterialDal>().As<ICartographicMaterialDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();
            builder.RegisterType<CityFacadeManager>().As<ICityFacadeService>().SingleInstance();

            builder.RegisterType<CommunicationManager>().As<ICommunicationService>().SingleInstance();
            builder.RegisterType<EfCommunicationDal>().As<ICommunicationDal>().SingleInstance();

            builder.RegisterType<ComposerManager>().As<IComposerService>().SingleInstance();
            builder.RegisterType<EfComposerDal>().As<IComposerDal>().SingleInstance();

            builder.RegisterType<ConsultantManager>().As<IConsultantService>().SingleInstance();
            builder.RegisterType<EfConsultantDal>().As<IConsultantDal>().SingleInstance();

            builder.RegisterType<CounterManager>().As<ICounterService>().SingleInstance();
            builder.RegisterType<EfCounterDal>().As<ICounterDal>().SingleInstance();

            builder.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>().SingleInstance();

            builder.RegisterType<CoverCapManager>().As<ICoverCapService>().SingleInstance();
            builder.RegisterType<EfCoverCapDal>().As<ICoverCapDal>().SingleInstance();

            builder.RegisterType<DepictionManager>().As<IDepictionService>().SingleInstance();
            builder.RegisterType<EfDepictionDal>().As<IDepictionDal>().SingleInstance();

            builder.RegisterType<DimensionManager>().As<IDimensionService>().SingleInstance();
            builder.RegisterType<EfDimensionDal>().As<IDimensionDal>().SingleInstance();

            builder.RegisterType<DirectorManager>().As<IDirectorService>().SingleInstance();
            builder.RegisterType<EfDirectorDal>().As<IDirectorDal>().SingleInstance();

            builder.RegisterType<DissertationManager>().As<IDissertationService>().SingleInstance();
            builder.RegisterType<EfDissertationDal>().As<IDissertationDal>().SingleInstance();

            builder.RegisterType<EditionManager>().As<IEditionService>().SingleInstance();
            builder.RegisterType<EfEditionDal>().As<IEditionDal>().SingleInstance();

            builder.RegisterType<EditorManager>().As<IEditorService>().SingleInstance();
            builder.RegisterType<EfEditorDal>().As<IEditorDal>().SingleInstance();

            builder.RegisterType<ElectronicsResourceManager>().As<IElectronicsResourceService>().SingleInstance();
            builder.RegisterType<EfElectronicsResourceDal>().As<IElectronicsResourceDal>().SingleInstance();

            builder.RegisterType<EMaterialFileManager>().As<IEMaterialFileService>().SingleInstance();
            builder.RegisterType<EfEMaterialFileDal>().As<IEMaterialFileDal>().SingleInstance();

            builder.RegisterType<EncyclopediaManager>().As<IEncyclopediaService>().SingleInstance();
            builder.RegisterType<EfEncyclopediaDal>().As<IEncyclopediaDal>().SingleInstance();

            builder.RegisterType<GraphicalImageManager>().As<IGraphicalImageService>().SingleInstance();
            builder.RegisterType<EfGraphicalImageDal>().As<IGraphicalImageDal>().SingleInstance();

            builder.RegisterType<GraphicDesignerManager>().As<IGraphicDesignerService>().SingleInstance();
            builder.RegisterType<EfGraphicDesignerDal>().As<IGraphicDesignerDal>().SingleInstance();

            builder.RegisterType<GraphicDirectorManager>().As<IGraphicDirectorService>().SingleInstance();
            builder.RegisterType<EfGraphicDirectorDal>().As<IGraphicDirectorDal>().SingleInstance();

            builder.RegisterType<ImageManager>().As<IImageService>().SingleInstance();
            builder.RegisterType<EfImageDal>().As<IImageDal>().SingleInstance();

            builder.RegisterType<InterpretersManager>().As<IInterpretersService>().SingleInstance();
            builder.RegisterType<EfInterpretersDal>().As<IInterpretersDal>().SingleInstance();

            builder.RegisterType<KitManager>().As<IKitService>().SingleInstance();
            builder.RegisterType<EfKitDal>().As<IKitDal>().SingleInstance();

            builder.RegisterType<LanguageManager>().As<ILanguageService>().SingleInstance();
            builder.RegisterType<EfLanguageDal>().As<ILanguageDal>().SingleInstance();

            builder.RegisterType<LibraryManager>().As<ILibraryService>().SingleInstance();
            builder.RegisterType<EfLibraryDal>().As<ILibraryDal>().SingleInstance();

            builder.RegisterType<MagazineManager>().As<IMagazineService>().SingleInstance();
            builder.RegisterType<EfMagazineDal>().As<IMagazineDal>().SingleInstance();

            builder.RegisterType<MicroformManager>().As<IMicroformService>().SingleInstance();
            builder.RegisterType<EfMicroformDal>().As<IMicroformDal>().SingleInstance();

            builder.RegisterType<MusicalNoteManager>().As<IMusicalNoteService>().SingleInstance();
            builder.RegisterType<EfMusicalNoteDal>().As<IMusicalNoteDal>().SingleInstance();

            builder.RegisterType<NewsPaperManager>().As<INewsPaperService>().SingleInstance();
            builder.RegisterType<EfNewsPaperDal>().As<INewsPaperDal>().SingleInstance();

            builder.RegisterType<Object3DManager>().As<IObject3DService>().SingleInstance();
            builder.RegisterType<EfObject3DDal>().As<IObject3DDal>().SingleInstance();

            builder.RegisterType<OtherPeopleManager>().As<IOtherPeopleService>().SingleInstance();
            builder.RegisterType<EfOtherPeopleDal>().As<IOtherPeopleDal>().SingleInstance();

            builder.RegisterType<PaintingManager>().As<IPaintingService>().SingleInstance();
            builder.RegisterType<EfPaintingDal>().As<IPaintingDal>().SingleInstance();

            builder.RegisterType<PosterManager>().As<IPosterService>().SingleInstance();
            builder.RegisterType<EfPosterDal>().As<IPosterDal>().SingleInstance();

            builder.RegisterType<PublisherManager>().As<IPublisherService>().SingleInstance();
            builder.RegisterType<EfPublisherDal>().As<IPublisherDal>().SingleInstance();

            builder.RegisterType<RedactionManager>().As<IRedactionService>().SingleInstance();
            builder.RegisterType<EfRedactionDal>().As<IRedactionDal>().SingleInstance();

            builder.RegisterType<ReferenceManager>().As<IReferenceService>().SingleInstance();
            builder.RegisterType<EfReferenceDal>().As<IReferenceDal>().SingleInstance();

            builder.RegisterType<ResearcherManager>().As<IResearcherService>().SingleInstance();
            builder.RegisterType<EfResearcherDal>().As<IResearcherDal>().SingleInstance();

            builder.RegisterType<StockManager>().As<IStockService>().SingleInstance();
            builder.RegisterType<EfStockDal>().As<IStockDal>().SingleInstance();

            builder.RegisterType<TechnicalNumberManager>().As<ITechnicalNumberService>().SingleInstance();
            builder.RegisterType<EfTechnicalNumberDal>().As<ITechnicalNumberDal>().SingleInstance();

            builder.RegisterType<TechnicalPlaceholderManager>().As<ITechnicalPlaceholderService>().SingleInstance();
            builder.RegisterType<EfTechnicalPlaceholderDal>().As<ITechnicalPlaceholderDal>().SingleInstance();

            builder.RegisterType<ThesisManager>().As<IThesisService>().SingleInstance();
            builder.RegisterType<EfThesisDal>().As<IThesisDal>().SingleInstance();

            builder.RegisterType<UniversityManager>().As<IUniversityService>().SingleInstance();
            builder.RegisterType<EfUniversityDal>().As<IUniversityDal>().SingleInstance();

            builder.RegisterType<WriterManager>().As<IWriterService>().SingleInstance();
            builder.RegisterType<EfWriterDal>().As<IWriterDal>().SingleInstance();


            // Todo daha sonra yapılacak  builder.RegisterType<AuthManager>().As<IAuthService>(); Not.
            // builder.RegisterType<JwtHelper>().As<ITokenHelper>()"



            // Bunu en son aç, istemeyen autofac modülerini çalıştırıyor. SORUNUN KAYNAĞI BULUNDU FAKAT FARKLI BİR SORUN ÇIKTI

            //  Last to open it, running autofac modules that don't want it.


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
               .EnableInterfaceInterceptors(new ProxyGenerationOptions()
               {
                   Selector = new AspectInterceptorSelector()
               }).SingleInstance();
        }
    }
}
