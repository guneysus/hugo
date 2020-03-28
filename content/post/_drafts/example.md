---
draft: true
title: example
---

<script src="https://unpkg.com/mermaid/dist/mermaid.min.js"></script>

{{<mermaid align="left">}}
graph LR;
    A[Hard edge] -->|Link text| B(Round edge)
    B --> C{Decision}
    C -->|One| D[Result one]
    C -->|Two| E[Result two]
{{< /mermaid >}}

<details>
  <summary>Click to expand!</summary>
  
## Heading

  1. A numbered
  2. list
     * With some
     * Sub bullets

</details>


{{% notice note %}}
A notice disclaimer
{{% /notice %}}


{{% notice info %}}
An information disclaimer
{{% /notice %}}

{{% notice tip %}}
A tip disclaimer
{{% /notice %}}

{{% notice warning %}}
A warning disclaimer
{{% /notice %}}