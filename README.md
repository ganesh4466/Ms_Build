<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net48</TargetFramework>
    <OutputType>Library</OutputType>
    <OutputPath>Binaries</OutputPath>
    <AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>
    <IsPackable>false</IsPackable>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
    <PreserveCompilationContext>true</PreserveCompilationContext>
  </PropertyGroup>

  <ItemGroup>
    <!-- FIXED: Use explicit versions that work together -->
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
    <PackageReference Include="MSTest.TestAdapter" Version="3.1.1">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="MSTest.TestFramework" Version="3.1.1" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\MyApp\MyApp.csproj" />
  </ItemGroup>

  <!-- FIXED: Copy ALL dependencies to output -->
  <Target Name="CopyAllDependencies" AfterTargets="Build">
    <ItemGroup>
      <AllDependencies Include="@(ReferenceCopyLocalPaths)" />
    </ItemGroup>
    <Copy SourceFiles="@(AllDependencies)" DestinationFolder="$(OutputPath)" SkipUnchangedFiles="true" />
  </Target>

</Project>
