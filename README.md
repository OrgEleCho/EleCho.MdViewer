# EleCho.MdViewer
简易的WPF Markdown渲染器，支持基础Markdown语法和深色模式。
> P.S. 该渲染器将Markdown文本渲染为ContentControl，而非FlowDocument。
## 使用
1. 添加xmlns命名空间
```xml
xmlns:mu="clr-namespace:EleCho.MdViewer.Markup;assembly=EleCho.MdViewer"
xmlns:md="clr-namespace:EleCho.MdViewer;assembly=EleCho.MdViewer"
```
2. 添加模板样式和暗色/亮色模式配置
```xml
<ResourceDictionary>
    <ResourceDictionary.MergedDictionaries>
        <mu:ControlsDictionary />
        <mu:ThemeDictionary ColorMode="Dark"/>
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>
```
3. 使用MdViewer控件
```xml
<ScrollViewer Grid.Column="1">
    <md:MarkdownViewer x:Name="MdViewer"
                       Content="{Binding Markdown}"/>
</ScrollViewer>
```

## 示例
见测试项目/src/MdTest  
![light](https://github.com/OrgEleCho/EleCho.MdViewer/assets/example_light.png)  
![dark](https://github.com/OrgEleCho/EleCho.MdViewer/assets/example_dark.png)
