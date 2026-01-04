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
- 

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
- `ClearAsync()` - Clear all local storage data
- `KeyAsync(int index)` - Get key name at specified index
- `GetAsync<T>(string key)` - Get stored value by key
- `KeysAsync()` - Get all storage keys
- `LengthAsync()` - Get number of stored items
- `SetAsync<T>(string key, T value)` - Store value with key
- `RemoveAsync(string key)` - Remove item by key
