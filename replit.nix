{ pkgs }: {
    deps = [
        pkgs.postgresql
        pkgs.nodePackages.prettier
        pkgs.dotnet-sdk_8
    ];
}