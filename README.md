<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <OutputPath>Binaries</OutputPath>
    <AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>
    <IsPackable>false</IsPackable>
    <!-- ADD THESE LINES -->
    <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
    <EnableUnsafeBinaryFormatterSerialization>true</EnableUnsafeBinaryFormatterSerialization>
    <RuntimeIdentifiers>win-x64</RuntimeIdentifiers>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
    <PackageReference Include="MSTest.TestAdapter" Version="3.1.1" />
    <PackageReference Include="MSTest.TestFramework" Version="3.1.1" />
    <!-- REMOVE coverlet.collector -->
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\MyApp\MyApp.csproj" />
  </ItemGroup>

  <!-- ADD THIS TARGET -->
  <Target Name="CopyRuntimeFiles" AfterTargets="Build">
    <ItemGroup>
      <RuntimeFiles Include="$(MSBuildThisFileDirectory)..\..\..\.dotnet\shared\Microsoft.NETCore.App\8.0.*\*.*" />
    </ItemGroup>
    <Copy SourceFiles="@(RuntimeFiles)" DestinationFolder="$(OutputPath)" SkipUnchangedFiles="true" />
  </Target>
</Project>
