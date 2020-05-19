# Handlebars.Net.Newtonsoft.Json
Template helpers designed to be used with Newtonsoft.Json.

## Group
Inspired by the work done for https://github.com/shannonmoeller/handlebars-group-by.

Template
```xml
<root>
    {{#group . "key"}}
        <group key="{{key}}">
            {{#each .}}
                <item>{{key}}:{{id}}</item>
            {{/each}}
        </group>
    {{/group}}
</root>
```

Json

```json
[
    {"key":"1", "id": "1"},
    {"key":"1", "id": "2"},
    {"key":"2", "id": "3"},
    {"key":"2", "id": "4"}
]
```

Output

```xml
<root>
    <group key="1">
        <item>1:1</item>
        <item>1:2</item>
    </group>
    <group key="2">
        <item>2:3</item>
        <item>2:4</item>
    </group>
</root>
```
