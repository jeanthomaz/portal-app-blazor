// using Core.Entities;
// using Core.Interfaces;
// using Core.ValueObjects;
// using Persistence.Repositories;
//
// namespace WebApp.Class
// {
//     public class Exemplo : IService
//     {
//         private readonly IRepository _repository;
//
//         public Task AddProjectAsync(Project project, Guid privateToken)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task AddReferenceToProjectAsync(Url reference, Guid privateToken)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task AddStudentToProjectAsync(Student student, Guid privateToken)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<string> GenerateTokenAsync()
//         {
//             throw new NotImplementedException();
//         }
//        
//         public List<Project> CriaExemplo()
//         {
//             Url oUrl1 = new Url();
//             oUrl1.Address = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
//             Url oUrl2 = new Url();
//             oUrl2.Address = "https://www.youtube.com/watch?v=_CQ_ehoRfsE";
//             Url oUrl3 = new Url();
//             oUrl3.Address = "https://www.youtube.com/watch?v=N5ST3mPLmy4";
//             Url oUrl4 = new Url();
//             oUrl4.Address = "https://www.youtube.com/watch?v=rKz1Ov6hmzU";
//
//             Student oAluno1 = new()
//             {
//                 Name = "Hatsune Miku",
//                 Role = "Programadora front end"
//             };
//
//             Student oAluno2 = new()
//             {
//                 Name = "Kagamine Rin",
//                 Role = "Programadora back end"
//             };
//
//             Student oAluno3 = new()
//             {
//                 Name = "Bernardo",
//                 Role = "Programador front end"
//             };
//
//             Student oAluno4 = new()
//             {
//                 Name = "Celine",
//                 Role = "Programadora back end"
//             };
//
//             Group oGrupo1 = new()
//             {
//                 GroupMembers = [oAluno1, oAluno2]
//             };
//
//             Group oGrupo2 = new()
//             {
//                 GroupMembers = [oAluno3, oAluno4]
//             };
//
//             Project oProject1 = new()
//             {
//                 Name = "Grupo ABC",
//                 Description = "Nosso trabalho é sobre piririn pururun...",
//                 TextBody = "Sed tortor dui, laoreet lobortis feugiat sed, tincidunt non orci. Sed condimentum nec sapien vitae gravida. Duis quis tortor sit amet nunc bibendum ornare. Nullam lorem nulla, congue at odio vel, facilisis semper mauris. Vestibulum diam augue, mollis at libero eget, gravida vehicula ipsum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec dapibus felis vel nisl pulvinar mollis. Etiam semper lorem nec ante dignissim tincidunt.",
//                 References = [oUrl1, oUrl2],
//                 Group = oGrupo1,
//                 IsDeleted = false
//             };
//
//             Project oProject2 = new()
//             {
//                 Name = "Portal",
//                 Description = "O trabalho do nosso grupo retrara como abablu abuble...",
//                 TextBody = "Nunc auctor est vel dolor hendrerit, eget pulvinar ligula maximus. Fusce non lorem mattis odio pharetra hendrerit a eu nisl. Nullam suscipit libero id arcu gravida, quis venenatis odio placerat. Vestibulum ut augue quis sapien hendrerit vehicula. Suspendisse faucibus tincidunt turpis, quis porta metus varius quis.",
//                 References = [oUrl3, oUrl4],
//                 Group = oGrupo2,
//                 IsDeleted = false
//             };
//
//             Project oProject3 = new()
//             {
//                 Name = "grupo3",
//                 Description = "O trabalho do nosso grupo retrara como abablu abuble...",
//                 TextBody = "Nunc auctor est vel dolor hendrerit, eget pulvinar ligula maximus. Fusce non lorem mattis odio pharetra hendrerit a eu nisl. Nullam suscipit libero id arcu gravida, quis venenatis odio placerat. Vestibulum ut augue quis sapien hendrerit vehicula. Suspendisse faucibus tincidunt turpis, quis porta metus varius quis.",
//                 References = [oUrl3, oUrl4],
//                 Group = oGrupo2,
//                 IsDeleted = false
//             };
//
//             Project oProject4 = new()
//             {
//                 Name = "Os impactos da inteligencia artificial na área de jogos",
//                 Description = "O trabalho do nosso grupo retrara como abablu abuble...",
//                 TextBody = "Nunc auctor est vel dolor hendrerit, eget pulvinar ligula maximus. Fusce non lorem mattis odio pharetra hendrerit a eu nisl. Nullam suscipit libero id arcu gravida, quis venenatis odio placerat. Vestibulum ut augue quis sapien hendrerit vehicula. Suspendisse faucibus tincidunt turpis, quis porta metus varius quis.",
//                 References = [oUrl3, oUrl4],
//                 Group = oGrupo2,
//                 IsDeleted = false
//             };
//
//             Project oProject5 = new()
//             {
//                 Name = "grupo5",
//                 Description = "O trabalho do nosso grupo retrara como abablu abuble...",
//                 TextBody = "Nunc auctor est vel dolor hendrerit, eget pulvinar ligula maximus. Fusce non lorem mattis odio pharetra hendrerit a eu nisl. Nullam suscipit libero id arcu gravida, quis venenatis odio placerat. Vestibulum ut augue quis sapien hendrerit vehicula. Suspendisse faucibus tincidunt turpis, quis porta metus varius quis.",
//                 References = [oUrl3, oUrl4],
//                 Group = oGrupo2,
//                 IsDeleted = false
//             };
//
//             Project oProject6 = new()
//             {
//                 Name = "grupo6",
//                 Description = "O trabalho do nosso grupo retrara como abablu abuble...",
//                 TextBody = "Nunc auctor est vel dolor hendrerit, eget pulvinar ligula maximus. Fusce non lorem mattis odio pharetra hendrerit a eu nisl. Nullam suscipit libero id arcu gravida, quis venenatis odio placerat. Vestibulum ut augue quis sapien hendrerit vehicula. Suspendisse faucibus tincidunt turpis, quis porta metus varius quis.",
//                 References = [oUrl3, oUrl4],
//                 Group = oGrupo2,
//                 IsDeleted = false
//             };
//
//             Project oProject7 = new()
//             {
//                 Name = "grupo7",
//                 Description = "O trabalho do nosso grupo retrara como abablu abuble...",
//                 TextBody = "Nunc auctor est vel dolor hendrerit, eget pulvinar ligula maximus. Fusce non lorem mattis odio pharetra hendrerit a eu nisl. Nullam suscipit libero id arcu gravida, quis venenatis odio placerat. Vestibulum ut augue quis sapien hendrerit vehicula. Suspendisse faucibus tincidunt turpis, quis porta metus varius quis.",
//                 References = [oUrl3, oUrl4],
//                 Group = oGrupo2,
//                 IsDeleted = false
//             };
//
//             Project oProject8 = new()
//             {
//                 Name = "grupo8",
//                 Description = "O trabalho do nosso grupo retrara como abablu abuble...",
//                 TextBody = "Nunc auctor est vel dolor hendrerit, eget pulvinar ligula maximus. Fusce non lorem mattis odio pharetra hendrerit a eu nisl. Nullam suscipit libero id arcu gravida, quis venenatis odio placerat. Vestibulum ut augue quis sapien hendrerit vehicula. Suspendisse faucibus tincidunt turpis, quis porta metus varius quis.",
//                 References = [oUrl3, oUrl4],
//                 Group = oGrupo2,
//                 IsDeleted = false
//             };
//
//             Project oProject9 = new()
//             {
//                 Name = "grupo9",
//                 Description = "O trabalho do nosso grupo retrara como abablu abuble...",
//                 TextBody = "Nunc auctor est vel dolor hendrerit, eget pulvinar ligula maximus. Fusce non lorem mattis odio pharetra hendrerit a eu nisl. Nullam suscipit libero id arcu gravida, quis venenatis odio placerat. Vestibulum ut augue quis sapien hendrerit vehicula. Suspendisse faucibus tincidunt turpis, quis porta metus varius quis.",
//                 References = [oUrl3, oUrl4],
//                 Group = oGrupo2,
//                 IsDeleted = false
//             };
//
//             List<Project> oProjects = [oProject1, oProject2, oProject3, oProject4, oProject5, oProject6, oProject7, oProject8, oProject9];
//             return oProjects;
//         }
//         
//         public async Task<Project> GetProjectByIdAsync(Guid id)
//         {
//             CriaExemplo();
//             return await _repository.GetProjectByIdAsync(id);
//         }
//
//         public async Task<List<Project>> ListProjectsAsync()
//         {
//             return CriaExemplo();
//             //return await _repository.ListProjectsAsync();
//         }
//
//         public Task<List<Token>> ListTokensAsync()
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task RemoveProjectAsync(Project project, Guid privateToken)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task RemoveReferenceFromProjectAsync(Url reference, Guid privateToken)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task RemoveStudentAsync(Student student, Guid privateToken)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task UpdateProjectAsync(Project project, Guid privateToken)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task UpdateStudentAsync(Student student, Guid privateToken)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }
