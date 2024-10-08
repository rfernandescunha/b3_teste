# Desafio do cálculo do CDB

Tecnologias e frameworks usados na solução:

ASP.NET Core and C# para p BackEnd <br />
Angular and TypeScript para o FrontEnd, [Angular CLI](https://github.com/angular/angular-cli) version 12.0.2 <br />
Bootstrap para layout das telas <br />

## Instalação

1. Clone o repositório:

   <b> git clone https://github.com/LeonardoVieiraNeto/DESAFIO-DO-CALCULO-DO-CDB.git </b>

1. Vá até a pasta clonada e execute <br />
<b>dotnet build</b> 

Exemplo:

leonardo@leonardo-Vostro-15-3510:~/Projetos/B3/DESAFIO-DO-CALCULO-DO-CDB$ dotnet build <br />
MSBuild version 17.6.8+c70978d4d for .NET<br />
  Determinando os projetos a serem restaurados... <br />
  /home/leonardo/Projetos/B3/DESAFIO-DO-CALCULO-DO-CDB/calculo-cdb.Logica/calculo-cdb.Logica.csproj restaurado (em 93 ms). <br />
  /home/leonardo/Projetos/B3/DESAFIO-DO-CALCULO-DO-CDB/app/calculo-cdb.AngularApp.csproj restaurado (em 193 ms). <br />
  /home/leonardo/Projetos/B3/DESAFIO-DO-CALCULO-DO-CDB/calculo-cdb.Test/calculo-cdb.Test.csproj restaurado (em 215 ms). <br />
  calculo-cdb.Logica -> /home/leonardo/Projetos/B3/DESAFIO-DO-CALCULO-DO-CDB/calculo-cdb.Logica/bin/Debug/net7.0/calculo-cdb.Logica.dll <br />
  calculo-cdb.Test -> /home/leonardo/Projetos/B3/DESAFIO-DO-CALCULO-DO-CDB/calculo-cdb.Test/bin/Debug/net7.0/calculo-cdb.Test.dll <br />
  calculo-cdb.AngularApp -> /home/leonardo/Projetos/B3/DESAFIO-DO-CALCULO-DO-CDB/app/bin/Debug/net7.0/calculo-cdb.AngularApp.dll <br />
  v20.5.1 <br />
  Restoring dependencies using 'npm'. This may take several minutes... <br />
  npm WARN deprecated @npmcli/move-file@2.0.1: This functionality has been moved to @npmcli/fs <br />
  npm WARN deprecated popper.js@1.16.1: You can find the new Popper v2 at @popperjs/core, this package is dedicated to the legacy v1 <br />
  
  added 953 packages, and audited 954 packages in 10s <br />
  
  107 packages are looking for funding <br />
    run `npm fund` for details <br />

## Executando a aplicação 

navegue até o diretório app <br />  
<b>cd app </b> <br />

execute <br />
<b> dotnet run </b>  <br />

A aplicação estará rodando e pode ser acessada em [App](https://localhost:7129/) <br />

## Executando testes unitário e relatórios de cobertura da camada lógica. 

Usei os testes os seguintes frameworks: 

coverlet.msbuild <br />
coverlet.collector <br />
MSTest.TestFramework <br />

Navegue até a pasta ./DESAFIO-DO-CALCULO-DO-CDB/calculo-cdb.Test e execute o comando  <br />
dotnet test --filter 'FullyQualifiedName!~calculo0cdb.Tests' /p:CollectCoverage=true <br />

## Executando os Testes unitários no Angular

Navegue até ./app/B3App e execute  <br /> 
<b> ng test </b>  <br />

Usei o [Karma](https://karma-runner.github.io) para executação e relatório dos testes do Angular



