# Maanfee JsInterop
**Maanfee JsInterop** is a JavaScript interop library for Blazor applications that provides jQuery-like DOM manipulation capabilities through C#.

# 🎯Features

- 🎬 **DOM Selection**: Query single or multiple elements using CSS selectors
- 🔧 **Content Manipulation**: Get/set text content, HTML content, and input values
- 📦 **Fluent API**: Chainable methods for concise code
- ⚡ **Type Safety**: Strongly typed return values
- 🎛️ **Async Support**: Full asynchronous operation support
- 🎯 **Frame Accuracy** - Precise frame navigation and seeking capabilities
- 🖥️ **Fullscreen API** - Comprehensive fullscreen control with event support
- 💾 **Local Storage** - Full local storage operations with type safety
- 📋 **Clipboard API** - Read, write, and clear clipboard content with HTML support
- 📥 **File Download** - Download files from streams and URLs
- 🖨️ **Print Service** - Print HTML elements with style preservation

# 🛠️ API Reference

## Core Services

### Dom Service
#### DOM Selection
- `QuerySelector(string selector)` - Select single element
- `QuerySelectorAll(string selector)` - Select multiple elements

#### Content Manipulation
##### Text Methods
- `TextAsync<T>()` - Get text content (returns string or IList<string>)
- `TextAsync(string text)` - Set text content

##### HTML Methods
- `HTMLAsync<T>()` - Get HTML content (returns string or IList<string>)
- `HTMLAsync(string html)` - Set HTML content

##### Value Methods
- `ValAsync<T>()` - Get input value (returns string or IList<string>)
- `ValAsync(string value)` - Set input value

##### Attribute Methods
- `AttrAsync<T>(string attributeName)` - Get attribute value (returns string or IList<string>)
- `AttrAsync(string attributeName, string attributeValue)` - Set attribute value

##### CSS Methods
- `CssAsync(string propertyName, string value)` - Set CSS property value
- `CssAsync<T>(string propertyName)` - Get CSS property value (returns string or IList<string>)

##### Class Methods
- `AddClassAsync(string className)` - Add CSS class to elements
- `RemoveClassAsync(string className)` - Remove CSS class from elements
- `ToggleClassAsync(string className)` - Toggle CSS class on elements
- `HasClassAsync(string className)` - Check if class exists (returns bool)
- `HasClassAllAsync(string className)` - Check class existence for all elements (returns IList<bool>)

#### Event Methods
- `ClickAsync()` - Trigger click event on selected elements

### Fullscreen Service
- `RequestFullscreenAsync(string elementId = null)` - Request fullscreen mode
- `ExitFullscreenAsync()` - Exit fullscreen mode
- `ToggleFullscreenAsync(string elementId = null)` - Toggle fullscreen mode
- `IsFullscreenAsync()` - Check if fullscreen is active
- `GetFullscreenElementAsync()` - Get current fullscreen element ID

#### Events
- `FullscreenChanged` - Event raised when fullscreen state changes

### LocalStorage Service

#### Basic Operations
- `ClearAsync()` - Clear all local storage data
- `KeyAsync(int index)` - Get key name at specified index (returns string)
- `LengthAsync()` - Get number of stored items (returns int?)
- `RemoveAsync(string key)` - Remove item by key

#### Read/Write Operations
- `GetAsync<T>(string key)` - Get stored value by key with type safety (returns T)
- `SetAsync<T>(string key, T value)` - Store value with key (auto-serializes)
- `KeysAsync()` - Get all storage keys (returns List<string>)

#### Configuration
- `ConfigureJsonOptions(Action<JsonSerializerOptions> configure)` - Configure JSON serialization settings globally

### Clipboard Service

#### Write Operations
- `WriteTextAsync(string text)` - Write text to clipboard (returns bool)
- `WriteHtmlAsync(string html)` - Write HTML to clipboard with plain text fallback (returns bool)

#### Read Operations
- `ReadTextAsync()` - Read text from clipboard (returns string)

#### Utility Methods
- `IsSupportedAsync()` - Check if Clipboard API is supported (returns bool)
- `ClearAsync()` - Clear clipboard content (returns bool)

### FileDownload Service

#### Download Methods
- `DownloadFileFromStream(string fileName, DotNetStreamReference stream)` - Download file from .NET stream
- `DownloadFileFromUrl(string fileName, string url)` - Download file from URL

### Print Service

#### Print Methods
- `PrintAsync(string id)` - Print HTML element with full style preservation


