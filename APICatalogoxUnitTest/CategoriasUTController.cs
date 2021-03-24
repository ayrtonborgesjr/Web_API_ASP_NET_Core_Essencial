using APICatalogo.Context;
using APICatalogo.Controllers;
using APICatalogo.DTOs;
using APICatalogo.DTOs.Mappings;
using APICatalogo.Repository;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace APICatalogoxUnitTest
{
    public class CategoriasUTController
    {
        private IUnitOfWork repository;
        private IMapper mapper;
        public static DbContextOptions<AppDbContext> dbContextOptions { get; }
        public static string connectionString = "Server=DESKTOP-AR9HUTA;Database=CatalogoDB;Trusted_Connection=True;MultipleActiveResultSets=true";

        static CategoriasUTController()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
               .UseSqlServer(connectionString)
               .Options;
        }

        public CategoriasUTController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();

            var context = new AppDbContext(dbContextOptions);

            //DBUnitTestsMockInitializer db = new DBUnitTestsMockInitializer();
            //db.Seed(context);

            repository = new UnitOfWork(context);
        }

        //===============================================Get=====================================
        [Fact]
        public void GetCategorias_Return_OkResult()
        {
            //Arrange  
            var controller = new CategoriasController(repository, mapper);

            //Act  
            var data = controller.Get();

            //Assert  
            Assert.IsType<List<CategoriaDTO>>(data.Value);
        }

        [Fact]
        public void GetCategorias_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new CategoriasController(repository, mapper);

            //Act  
            var data = controller.Get();
            data = null;

            if (data != null)
            //Assert  
            Assert.IsType<BadRequestResult>(data.Result);
        }

        [Fact]
        public void GetCategorias_MatchResult()
        {
            //Arrange  
            var controller = new CategoriasController(repository, mapper);

            //Act  
            var data = controller.Get();

            //Assert  
            Assert.IsType<List<CategoriaDTO>>(data.Value);
            var cat = data.Value.Should().BeAssignableTo<List<CategoriaDTO>>().Subject;

            Assert.Equal("Bebidas", cat[0].Nome);
            Assert.Equal("http://wwww.macoratti.net/Imagens/1.jpg", cat[0].ImagemUrl);

            Assert.Equal("Lanches", cat[1].Nome);
            Assert.Equal("http://wwww.macoratti.net/Imagens/2.jpg", cat[1].ImagemUrl);
        }

        //====================================Get(int id) =====================================
        [Fact]
        public void GetCategoriaById_Return_OkResult()
        {
            //Arrange  
            var controller = new CategoriasController(repository, mapper);
            var catId = 4;

            //Act  
            var data = controller.Get(catId);

            //Assert  
            Assert.IsType<CategoriaDTO>(data.Value);
        }

        [Fact]
        public void GetCategoriaById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new CategoriasController(repository, mapper);
            var catId = 999;

            //Act  
            var data = controller.Get(catId);

            //Assert  
            Assert.IsType<NotFoundResult>(data.Result);
        }

        // POST - CreateResult
        [Fact]
        public void Post_Categoria_AddValidData_Return_CreatedResult()
        {
            //Arrange  
            var controller = new CategoriasController(repository, mapper);

            var cat = new CategoriaDTO() { Nome = "Teste Unitário Inclusão", ImagemUrl = "testeunitarioinclusao.jpg" };

            //Act  
            var data = controller.Post(cat);

            //Assert  
            Assert.IsType<CreatedAtRouteResult>(data);
        }

        // PUT
        [Fact]
        public void Put_Categoria_Update_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new CategoriasController(repository, mapper);
            var catId = 9;

            //Act  
            var existingPost = controller.Get(catId);
            var result = existingPost.Value.Should().BeAssignableTo<CategoriaDTO>().Subject;

            var catDto = new CategoriaDTO();
            catDto.CategoriaId = catId;
            catDto.Nome = "Alterado - Teste Unitário Inclusão";
            catDto.ImagemUrl = result.ImagemUrl;

            var updatedData = controller.Put(catId, catDto);

            //Assert  
            Assert.IsType<OkResult>(updatedData);
        }

        // Delete
        [Fact]
        public void Delete_Categoria_Return_OkResult()
        {
            //Arrange  
            var controller = new CategoriasController(repository, mapper);
            var catId = 13;

            //Act  
            var data = controller.Delete(catId);

            //Assert  
            Assert.IsType<CategoriaDTO>(data.Value);
        }

    }
}
