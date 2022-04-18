using Contratos;
using Microsoft.AspNetCore.Mvc;
using Repositorio;

namespace CadastroProdutos.Extensoes
{
    public static class ExtensoesServicos
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        

        public static void Init(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(provider => configuration);
            services.AddSingleton<Entidade.configuracao.MeuBanco>();
        }

        

        //public static void ConfigureDominioServices(this IServiceCollection services)
        //{
        //    services.AddScoped<ICategoriaService, CategoriaService>();
        //    services.AddScoped<IContaService, ContaService>();
        //    services.AddScoped<IUsuarioService, UsuarioService>();
        //    services.AddScoped<ICartaoService, CartaoService>();
        //    services.AddScoped<ICondicaoDePagamentoService, CondicaoDePagamentoService>();
        //    services.AddScoped<IContasAPagarService, ContaAPagarService>();
        //    services.AddScoped<IContasAReceberService, ContaAReceberService>();
        //    services.AddScoped<ISubCategoriaService, SubGrupoService>();
        //    services.AddScoped<ITabelaService, TabelaService>();
        //    services.AddScoped<ITipoDeDocumentoService, TipoDeDocumentoService>();
        //    services.AddScoped<IMovimentacaoService, MovimentacaoService>();
        //    services.AddScoped<ISenhaService, SenhaService>();
        //}

        public static void ConfigureRepositoryDapperWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositorioWrapper, RepositorioWrapper>();
        }

       

       

        public static void AutenticacoesViaRedes(this IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
        }
    }
}

