## Branching & Release Flow

```mermaid
flowchart LR
  subgraph Development
    FEAT[feat/*]
    FIX[fix/*]
  end

  MASTER[master]
  RC[rc]
  RELEASE[release]

  NUGET_RC[(NuGet\npre-release)]
  NUGET_REL[(NuGet\nrelease)]

  FEAT -->|PR| MASTER
  FIX -->|PR| MASTER

  MASTER -->|PR| RC
  RC -->|PR| RELEASE

  RC -->|publish rc| NUGET_RC
  RELEASE -->|publish| NUGET_REL

  %% Guards / blocked paths
  FEAT -. blocked .-> RC
  FEAT -. blocked .-> RELEASE
  FIX  -. blocked .-> RC
  FIX  -. blocked .-> RELEASE
  MASTER -. blocked .-> RELEASE
  RC -. blocked .-> MASTER
```