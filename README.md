# Rettio API

## Hvordan å laste ned .Net

-   For å laste ned .Net er det enklest å først ha homebrew innstallert, derfor kjører man helst alle linjene under i rekkefølge. Om du har homebrew så hopp over dette steget.
-   Du må gå inn i konsollen og kjøre linjene med kode under:
    -   /bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install.sh)"
    -   brew install --cask dotnet-sdk
    -   dotnet --version

## Hvordan å kjøre APIet lokalt

-   Kjør linjen med kode under inne i mappen fra terminalen.
-   Først finner du riktig mappe ved bruke cd "din path"
-   Når du finner riktig mappe kjør denne koden i terminalen;
    -   dotnet watch
