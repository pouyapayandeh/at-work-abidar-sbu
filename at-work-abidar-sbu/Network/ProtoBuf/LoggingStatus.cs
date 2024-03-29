// Generated by ProtoGen, Version=2.4.1.555, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48.  DO NOT EDIT!
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.ProtocolBuffers;
using pbc = global::Google.ProtocolBuffers.Collections;
using pbd = global::Google.ProtocolBuffers.Descriptors;
using scg = global::System.Collections.Generic;
namespace atwork_pb_msgs {
  
  namespace Proto {
    
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public static partial class LoggingStatus {
    
      #region Extension registration
      public static void RegisterAllExtensions(pb::ExtensionRegistry registry) {
      }
      #endregion
      #region Static variables
      internal static pbd::MessageDescriptor internal__static_atwork_pb_msgs_LoggingStatus__Descriptor;
      internal static pb::FieldAccess.FieldAccessorTable<global::atwork_pb_msgs.LoggingStatus, global::atwork_pb_msgs.LoggingStatus.Builder> internal__static_atwork_pb_msgs_LoggingStatus__FieldAccessorTable;
      #endregion
      #region Descriptor
      public static pbd::FileDescriptor Descriptor {
        get { return descriptor; }
      }
      private static pbd::FileDescriptor descriptor;
      
      static LoggingStatus() {
        byte[] descriptorData = global::System.Convert.FromBase64String(
            string.Concat(
              "ChNMb2dnaW5nU3RhdHVzLnByb3RvEg5hdHdvcmtfcGJfbXNncyJLCg1Mb2dn", 
              "aW5nU3RhdHVzEhIKCmlzX2xvZ2dpbmcYASACKAgiJgoIQ29tcFR5cGUSDAoH", 
              "Q09NUF9JRBDQDxIMCghNU0dfVFlQRRBvQi0KFm9yZy5hdHdvcmsuY29tbW9u", 
            "X21zZ3NCE0xvZ2dpbmdTdGF0dXNQcm90b3M="));
        pbd::FileDescriptor.InternalDescriptorAssigner assigner = delegate(pbd::FileDescriptor root) {
          descriptor = root;
          internal__static_atwork_pb_msgs_LoggingStatus__Descriptor = Descriptor.MessageTypes[0];
          internal__static_atwork_pb_msgs_LoggingStatus__FieldAccessorTable = 
              new pb::FieldAccess.FieldAccessorTable<global::atwork_pb_msgs.LoggingStatus, global::atwork_pb_msgs.LoggingStatus.Builder>(internal__static_atwork_pb_msgs_LoggingStatus__Descriptor,
                  new string[] { "IsLogging", });
          return null;
        };
        pbd::FileDescriptor.InternalBuildGeneratedFileFrom(descriptorData,
            new pbd::FileDescriptor[] {
            }, assigner);
      }
      #endregion
      
    }
  }
  #region Messages
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  public sealed partial class LoggingStatus : pb::GeneratedMessage<LoggingStatus, LoggingStatus.Builder> {
    private LoggingStatus() { }
    private static readonly LoggingStatus defaultInstance = new LoggingStatus().MakeReadOnly();
    private static readonly string[] _loggingStatusFieldNames = new string[] { "is_logging" };
    private static readonly uint[] _loggingStatusFieldTags = new uint[] { 8 };
    public static LoggingStatus DefaultInstance {
      get { return defaultInstance; }
    }
    
    public override LoggingStatus DefaultInstanceForType {
      get { return DefaultInstance; }
    }
    
    protected override LoggingStatus ThisMessage {
      get { return this; }
    }
    
    public static pbd::MessageDescriptor Descriptor {
      get { return global::atwork_pb_msgs.Proto.LoggingStatus.internal__static_atwork_pb_msgs_LoggingStatus__Descriptor; }
    }
    
    protected override pb::FieldAccess.FieldAccessorTable<LoggingStatus, LoggingStatus.Builder> InternalFieldAccessors {
      get { return global::atwork_pb_msgs.Proto.LoggingStatus.internal__static_atwork_pb_msgs_LoggingStatus__FieldAccessorTable; }
    }
    
    #region Nested types
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public static partial class Types {
      public enum CompType {
        COMP_ID = 2000,
        MSG_TYPE = 111,
      }
      
    }
    #endregion
    
    public const int IsLoggingFieldNumber = 1;
    private bool hasIsLogging;
    private bool isLogging_;
    public bool HasIsLogging {
      get { return hasIsLogging; }
    }
    public bool IsLogging {
      get { return isLogging_; }
    }
    
    public override bool IsInitialized {
      get {
        if (!hasIsLogging) return false;
        return true;
      }
    }
    
    public override void WriteTo(pb::ICodedOutputStream output) {
      CalcSerializedSize();
      string[] field_names = _loggingStatusFieldNames;
      if (hasIsLogging) {
        output.WriteBool(1, field_names[0], IsLogging);
      }
      UnknownFields.WriteTo(output);
    }
    
    private int memoizedSerializedSize = -1;
    public override int SerializedSize {
      get {
        int size = memoizedSerializedSize;
        if (size != -1) return size;
        return CalcSerializedSize();
      }
    }
    
    private int CalcSerializedSize() {
      int size = memoizedSerializedSize;
      if (size != -1) return size;
      
      size = 0;
      if (hasIsLogging) {
        size += pb::CodedOutputStream.ComputeBoolSize(1, IsLogging);
      }
      size += UnknownFields.SerializedSize;
      memoizedSerializedSize = size;
      return size;
    }
    public static LoggingStatus ParseFrom(pb::ByteString data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static LoggingStatus ParseFrom(pb::ByteString data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static LoggingStatus ParseFrom(byte[] data) {
      return ((Builder) CreateBuilder().MergeFrom(data)).BuildParsed();
    }
    public static LoggingStatus ParseFrom(byte[] data, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(data, extensionRegistry)).BuildParsed();
    }
    public static LoggingStatus ParseFrom(global::System.IO.Stream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static LoggingStatus ParseFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    public static LoggingStatus ParseDelimitedFrom(global::System.IO.Stream input) {
      return CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }
    public static LoggingStatus ParseDelimitedFrom(global::System.IO.Stream input, pb::ExtensionRegistry extensionRegistry) {
      return CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }
    public static LoggingStatus ParseFrom(pb::ICodedInputStream input) {
      return ((Builder) CreateBuilder().MergeFrom(input)).BuildParsed();
    }
    public static LoggingStatus ParseFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
      return ((Builder) CreateBuilder().MergeFrom(input, extensionRegistry)).BuildParsed();
    }
    private LoggingStatus MakeReadOnly() {
      return this;
    }
    
    public static Builder CreateBuilder() { return new Builder(); }
    public override Builder ToBuilder() { return CreateBuilder(this); }
    public override Builder CreateBuilderForType() { return new Builder(); }
    public static Builder CreateBuilder(LoggingStatus prototype) {
      return new Builder(prototype);
    }
    
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public sealed partial class Builder : pb::GeneratedBuilder<LoggingStatus, Builder> {
      protected override Builder ThisBuilder {
        get { return this; }
      }
      public Builder() {
        result = DefaultInstance;
        resultIsReadOnly = true;
      }
      internal Builder(LoggingStatus cloneFrom) {
        result = cloneFrom;
        resultIsReadOnly = true;
      }
      
      private bool resultIsReadOnly;
      private LoggingStatus result;
      
      private LoggingStatus PrepareBuilder() {
        if (resultIsReadOnly) {
          LoggingStatus original = result;
          result = new LoggingStatus();
          resultIsReadOnly = false;
          MergeFrom(original);
        }
        return result;
      }
      
      public override bool IsInitialized {
        get { return result.IsInitialized; }
      }
      
      protected override LoggingStatus MessageBeingBuilt {
        get { return PrepareBuilder(); }
      }
      
      public override Builder Clear() {
        result = DefaultInstance;
        resultIsReadOnly = true;
        return this;
      }
      
      public override Builder Clone() {
        if (resultIsReadOnly) {
          return new Builder(result);
        } else {
          return new Builder().MergeFrom(result);
        }
      }
      
      public override pbd::MessageDescriptor DescriptorForType {
        get { return global::atwork_pb_msgs.LoggingStatus.Descriptor; }
      }
      
      public override LoggingStatus DefaultInstanceForType {
        get { return global::atwork_pb_msgs.LoggingStatus.DefaultInstance; }
      }
      
      public override LoggingStatus BuildPartial() {
        if (resultIsReadOnly) {
          return result;
        }
        resultIsReadOnly = true;
        return result.MakeReadOnly();
      }
      
      public override Builder MergeFrom(pb::IMessage other) {
        if (other is LoggingStatus) {
          return MergeFrom((LoggingStatus) other);
        } else {
          base.MergeFrom(other);
          return this;
        }
      }
      
      public override Builder MergeFrom(LoggingStatus other) {
        if (other == global::atwork_pb_msgs.LoggingStatus.DefaultInstance) return this;
        PrepareBuilder();
        if (other.HasIsLogging) {
          IsLogging = other.IsLogging;
        }
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }
      
      public override Builder MergeFrom(pb::ICodedInputStream input) {
        return MergeFrom(input, pb::ExtensionRegistry.Empty);
      }
      
      public override Builder MergeFrom(pb::ICodedInputStream input, pb::ExtensionRegistry extensionRegistry) {
        PrepareBuilder();
        pb::UnknownFieldSet.Builder unknownFields = null;
        uint tag;
        string field_name;
        while (input.ReadTag(out tag, out field_name)) {
          if(tag == 0 && field_name != null) {
            int field_ordinal = global::System.Array.BinarySearch(_loggingStatusFieldNames, field_name, global::System.StringComparer.Ordinal);
            if(field_ordinal >= 0)
              tag = _loggingStatusFieldTags[field_ordinal];
            else {
              if (unknownFields == null) {
                unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
              }
              ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
              continue;
            }
          }
          switch (tag) {
            case 0: {
              throw pb::InvalidProtocolBufferException.InvalidTag();
            }
            default: {
              if (pb::WireFormat.IsEndGroupTag(tag)) {
                if (unknownFields != null) {
                  this.UnknownFields = unknownFields.Build();
                }
                return this;
              }
              if (unknownFields == null) {
                unknownFields = pb::UnknownFieldSet.CreateBuilder(this.UnknownFields);
              }
              ParseUnknownField(input, unknownFields, extensionRegistry, tag, field_name);
              break;
            }
            case 8: {
              result.hasIsLogging = input.ReadBool(ref result.isLogging_);
              break;
            }
          }
        }
        
        if (unknownFields != null) {
          this.UnknownFields = unknownFields.Build();
        }
        return this;
      }
      
      
      public bool HasIsLogging {
        get { return result.hasIsLogging; }
      }
      public bool IsLogging {
        get { return result.IsLogging; }
        set { SetIsLogging(value); }
      }
      public Builder SetIsLogging(bool value) {
        PrepareBuilder();
        result.hasIsLogging = true;
        result.isLogging_ = value;
        return this;
      }
      public Builder ClearIsLogging() {
        PrepareBuilder();
        result.hasIsLogging = false;
        result.isLogging_ = false;
        return this;
      }
    }
    static LoggingStatus() {
      object.ReferenceEquals(global::atwork_pb_msgs.Proto.LoggingStatus.Descriptor, null);
    }
  }
  
  #endregion
  
}

#endregion Designer generated code
