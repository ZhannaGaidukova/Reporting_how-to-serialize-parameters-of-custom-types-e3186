<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))**
<!-- default file list end -->
# How to serialize parameters of custom types


<p>This example demonstrates the capability to provide XML serialization of custom parameter types.</p><p>In particular, it shows how you can save a report, along with its parameters of the <strong>System.Enum</strong> type, to XML file.</p><p>To do this, override the <strong>ReportStorageExtension</strong> class, and register a custom <strong>ReportDesignExtension</strong>, which implements the data source serialization functionality.</p><p>To serialize custom objects and properties, specify the <strong>XtraSerializ</strong><strong>ableProperty</strong> attribute with the <strong>XtraSerializationVisibility.Reference</strong> parameter (this parameter defines whether or not an object should be serialized by a reference).</p>

<br/>


