<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net48</TargetFramework>
    <OutputType>Library</OutputType>
    <OutputPath>Binaries</OutputPath>
    <AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>
    <IsPackable>false</IsPackable>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <LangVersion>latest</LangVersion>
  </PropertyGroup>

  <ItemGroup>
    <!-- Use specific version of Test SDK that matches VS -->
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
    <PackageReference Include="MSTest.TestAdapter" Version="3.1.1" />
    <PackageReference Include="MSTest.TestFramework" Version="3.1.1" />
    <!-- For xUnit (if using xUnit instead) -->
    <!--<PackageReference Include="xunit" Version="2.6.3" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.5.6">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>-->
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\MyApp\MyApp.csproj" />
  </ItemGroup>

  <!-- Copy test adapters to output -->
  <Target Name="CopyTestAdapters" AfterTargets="Build">
    <ItemGroup>
      <TestAdapterFiles Include="$(NuGetPackageRoot)\mstest.testadapter\3.1.1\build\_common\*.*" />
      <TestAdapterFiles Include="$(NuGetPackageRoot)\microsoft.testplatform.testhost\17.8.0\build\netcoreapp3.1\*.*" />
    </ItemGroup>
    <Copy SourceFiles="@(TestAdapterFiles)" DestinationFolder="$(OutputPath)" SkipUnchangedFiles="true" />
  </Target>

</Project>
