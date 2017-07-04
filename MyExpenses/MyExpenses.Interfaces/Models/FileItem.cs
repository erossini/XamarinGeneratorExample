using System;
namespace MyExpenses.Interfaces
{
 public class FileItem
 {
  /// <summary>
  /// Gets or sets the identifier.
  /// </summary>
  /// <value>The identifier.</value>
  public string Id { get; set; }

  /// <summary>
  /// Gets or sets the name of the directory or file.
  /// </summary>
  /// <value>The name of the file.</value>
  public string ItemName { get; set; }

  /// <summary>
  /// Gets or sets the file directory or path.
  /// </summary>
  /// <value>The file path.</value>
  public string ItemPath { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether this instance is header.
  /// </summary>
  /// <value><c>true</c> if this instance is header; otherwise, <c>false</c>.</value>
  public bool IsHeader { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether this instance is dir.
  /// </summary>
  /// <value><c>true</c> if this instance is dir; otherwise, <c>false</c>.</value>
  public bool IsDir { get; set; }

  /// <summary>
  /// Gets or sets the file size in bytes.
  /// </summary>
  /// <value>The file size bytes</value>
  public float FileSizeB { get; set; }

  /// <summary>
  /// Gets the file size kb.
  /// </summary>
  /// <value>The file size kb.</value>
  public float FileSizeKB
  {
   get { return FileSizeB / 1024.0f; }
  }

  /// <summary>
  /// Gets the file size mb.
  /// </summary>
  /// <value>The file size mb.</value>
  public float fileSizeMB
  {
   get { return FileSizeKB / 1024.0f; }
  }

  /// <summary>
  /// Gets the summary.
  /// </summary>
  /// <value>The summary.</value>
  public string Summary
  {
   get { return ItemName + " (" + Math.Round(fileSizeMB, 2) + " Mb)"; }
  }

  /// <summary>
  /// Gets or sets the date created.
  /// </summary>
  /// <value>The date created.</value>
  public DateTime DateCreated { get; set; }

  /// <summary>
  /// Gets or sets the extension.
  /// </summary>
  /// <value>The extension.</value>
  public string Extension { get; set; }
 }
}
