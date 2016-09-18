/* Copyright (c) 2016 Xamarin. */

/* NOTE: this is auto-generated from IDL */
/* From ppb_file_io.idl modified Thu May 12 07:00:02 2016. */

using System;
using System.Runtime.InteropServices;

namespace PepperSharp {


/**
 * @file
 * This file defines the API to create a file i/o object.
 */


/**
 * @addtogroup Enums
 * @{
 */
/**
 * The PP_FileOpenFlags enum contains file open constants.
 */
public enum PPFileOpenFlags {
  /** Requests read access to a file. */
  FileopenflagRead = 1<<0,
  /**
   * Requests write access to a file.  May be combined with
   * <code>PP_FILEOPENFLAG_READ</code> to request read and write access.
   */
  FileopenflagWrite = 1<<1,
  /**
   * Requests that the file be created if it does not exist.  If the file
   * already exists, then this flag is ignored unless
   * <code>PP_FILEOPENFLAG_EXCLUSIVE</code> was also specified, in which case
   * FileIO::Open() will fail.
   */
  FileopenflagCreate = 1<<2,
  /**
   * Requests that the file be truncated to length 0 if it exists and is a
   * regular file. <code>PP_FILEOPENFLAG_WRITE</code> must also be specified.
   */
  FileopenflagTruncate = 1<<3,
  /**
   * Requests that the file is created when this flag is combined with
   * <code>PP_FILEOPENFLAG_CREATE</code>.  If this flag is specified, and the
   * file already exists, then the FileIO::Open() call will fail.
   */
  FileopenflagExclusive = 1<<4,
  /**
   * Requests write access to a file, but writes will always occur at the end of
   * the file. Mututally exclusive with <code>PP_FILEOPENFLAG_WRITE</code>.
   *
   * This is only supported in version 1.2 (Chrome 29) and later.
   */
  FileopenflagAppend = 1<<5
}
/**
 * @}
 */

/**
 * @addtogroup Interfaces
 * @{
 */
/**
 * The <code>PPB_FileIO</code> struct is used to operate on a regular file
 * (PP_FileType_Regular).
 */
internal static partial class PPBFileIO {
  [DllImport("PepperPlugin", EntryPoint = "PPB_FileIO_Create")]
  extern static PPResource _Create ( PPInstance instance);

  /**
   * Create() creates a new FileIO object.
   *
   * @param[in] instance A <code>PP_Instance</code> identifying the instance
   * with the file.
   *
   * @return A <code>PP_Resource</code> corresponding to a FileIO if
   * successful or 0 if the module is invalid.
   */
  public static PPResource Create ( PPInstance instance)
  {
  	return _Create (instance);
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_FileIO_IsFileIO")]
  extern static PPBool _IsFileIO ( PPResource resource);

  /**
   * IsFileIO() determines if the provided resource is a FileIO.
   *
   * @param[in] resource A <code>PP_Resource</code> corresponding to a FileIO.
   *
   * @return <code>PP_TRUE</code> if the resource is a
   * <code>PPB_FileIO</code>, <code>PP_FALSE</code> if the resource is
   * invalid or some type other than <code>PPB_FileIO</code>.
   */
  public static PPBool IsFileIO ( PPResource resource)
  {
  	return _IsFileIO (resource);
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_FileIO_Open")]
  extern static int _Open ( PPResource file_io,
                            PPResource file_ref,
                            int open_flags,
                            PPCompletionCallback callback);

  /**
   * Open() opens the specified regular file for I/O according to the given
   * open flags, which is a bit-mask of the <code>PP_FileOpenFlags</code>
   * values. Upon success, the corresponding file is classified as "in use"
   * by this FileIO object until such time as the FileIO object is closed
   * or destroyed.
   *
   * @param[in] file_io A <code>PP_Resource</code> corresponding to a
   * FileIO.
   * @param[in] file_ref A <code>PP_Resource</code> corresponding to a file
   * reference.
   * @param[in] open_flags A bit-mask of the <code>PP_FileOpenFlags</code>
   * values.
   * @param[in] callback A <code>PP_CompletionCallback</code> to be called upon
   * completion of Open().
   *
   * @return An int32_t containing an error code from <code>pp_errors.h</code>.
   */
  public static int Open ( PPResource file_io,
                           PPResource file_ref,
                           int open_flags,
                           PPCompletionCallback callback)
  {
  	return _Open (file_io, file_ref, open_flags, callback);
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_FileIO_Query")]
  extern static int _Query ( PPResource file_io,
                            out PPFileInfo info,
                             PPCompletionCallback callback);

  /**
   * Query() queries info about the file opened by this FileIO object. The
   * FileIO object must be opened, and there must be no other operations
   * pending.
   *
   * @param[in] file_io A <code>PP_Resource</code> corresponding to a
   * FileIO.
   * @param[out] info The <code>PP_FileInfo</code> structure representing all
   * information about the file.
   * @param[in] callback A <code>PP_CompletionCallback</code> to be called upon
   * completion of Query(). <code>info</code> must remain valid until after the
   * callback runs. If you pass a blocking callback, <code>info</code> must
   * remain valid until after Query() returns.
   *
   * @return An int32_t containing an error code from <code>pp_errors.h</code>.
   * PP_ERROR_FAILED will be returned if the file isn't opened, and
   * PP_ERROR_INPROGRESS will be returned if there is another operation pending.
   */
  public static int Query ( PPResource file_io,
                           out PPFileInfo info,
                            PPCompletionCallback callback)
  {
  	return _Query (file_io, out info, callback);
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_FileIO_Touch")]
  extern static int _Touch ( PPResource file_io,
                             double last_access_time,
                             double last_modified_time,
                             PPCompletionCallback callback);

  /**
   * Touch() Updates time stamps for the file opened by this FileIO object.
   * This function will fail if the FileIO object has not been opened. The
   * FileIO object must be opened, and there must be no other operations
   * pending.
   *
   * @param[in] file_io A <code>PP_Resource</code> corresponding to a file
   * FileIO.
   * @param[in] last_access_time The last time the FileIO was accessed.
   * @param[in] last_modified_time The last time the FileIO was modified.
   * @param[in] callback A <code>PP_CompletionCallback</code> to be called upon
   * completion of Touch().
   *
   * @return An int32_t containing an error code from <code>pp_errors.h</code>.
   * PP_ERROR_FAILED will be returned if the file isn't opened, and
   * PP_ERROR_INPROGRESS will be returned if there is another operation pending.
   */
  public static int Touch ( PPResource file_io,
                            double last_access_time,
                            double last_modified_time,
                            PPCompletionCallback callback)
  {
  	return _Touch (file_io, last_access_time, last_modified_time, callback);
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_FileIO_Read")]
  extern static int _Read ( PPResource file_io,
                            long offset,
                           IntPtr buffer,
                            int bytes_to_read,
                            PPCompletionCallback callback);

  /**
   * Read() reads from an offset in the file.  The size of the buffer must be
   * large enough to hold the specified number of bytes to read.  This function
   * might perform a partial read, meaning all the requested bytes
   * might not be returned, even if the end of the file has not been reached.
   * The FileIO object must have been opened with read access.
   *
   * ReadToArray() is preferred to Read() when doing asynchronous operations.
   *
   * @param[in] file_io A <code>PP_Resource</code> corresponding to a file
   * FileIO.
   * @param[in] offset The offset into the file.
   * @param[in] buffer The buffer to hold the specified number of bytes read.
   * @param[in] bytes_to_read The number of bytes to read from
   * <code>offset</code>.
   * @param[in] callback A <code>PP_CompletionCallback</code> to be called upon
   * completion of Read(). <code>buffer</code> must remain valid until after
   * the callback runs. If you pass a blocking callback, <code>buffer</code>
   * must remain valid until after Read() returns.
   *
   * @return The number of bytes read or an error code from
   * <code>pp_errors.h</code>. If the return value is 0, then end-of-file was
   * reached. It is valid to call Read() multiple times with a completion
   * callback to queue up parallel reads from the file, but pending reads
   * cannot be interleaved with other operations.
   */
  public static int Read ( PPResource file_io,
                           long offset,
                          byte[] buffer,
                           int bytes_to_read,
                           PPCompletionCallback callback)
  {
  	if (buffer == null)
  		throw new ArgumentNullException ("buffer");

  	unsafe
  	{
  		fixed (byte* buffer_ = &buffer[0])
  		{
  			return _Read (file_io, offset, (IntPtr) buffer_, bytes_to_read, callback);
  		}
  	}
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_FileIO_Write")]
  extern static int _Write ( PPResource file_io,
                             long offset,
                            IntPtr buffer,
                             int bytes_to_write,
                             PPCompletionCallback callback);

  /**
   * Write() writes to an offset in the file.  This function might perform a
   * partial write. The FileIO object must have been opened with write access.
   *
   * @param[in] file_io A <code>PP_Resource</code> corresponding to a file
   * FileIO.
   * @param[in] offset The offset into the file.
   * @param[in] buffer The buffer to hold the specified number of bytes read.
   * @param[in] bytes_to_write The number of bytes to write to
   * <code>offset</code>.
   * @param[in] callback A <code>PP_CompletionCallback</code> to be called upon
   * completion of Write().
   *
   * @return The number of bytes written or an error code from
   * <code>pp_errors.h</code>. If the return value is 0, then end-of-file was
   * reached. It is valid to call Write() multiple times with a completion
   * callback to queue up parallel writes to the file, but pending writes
   * cannot be interleaved with other operations.
   */
  public static int Write ( PPResource file_io,
                            long offset,
                           byte[] buffer,
                            int bytes_to_write,
                            PPCompletionCallback callback)
  {
  	if (buffer == null)
  		throw new ArgumentNullException ("buffer");

  	unsafe
  	{
  		fixed (byte* buffer_ = &buffer[0])
  		{
  			return _Write (file_io, offset, (IntPtr) buffer_,
                                      bytes_to_write,
                                      callback);
  		}
  	}
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_FileIO_SetLength")]
  extern static int _SetLength ( PPResource file_io,
                                 long length,
                                 PPCompletionCallback callback);

  /**
   * SetLength() sets the length of the file.  If the file size is extended,
   * then the extended area of the file is zero-filled. The FileIO object must
   * have been opened with write access and there must be no other operations
   * pending.
   *
   * @param[in] file_io A <code>PP_Resource</code> corresponding to a file
   * FileIO.
   * @param[in] length The length of the file to be set.
   * @param[in] callback A <code>PP_CompletionCallback</code> to be called upon
   * completion of SetLength().
   *
   * @return An int32_t containing an error code from <code>pp_errors.h</code>.
   * PP_ERROR_FAILED will be returned if the file isn't opened, and
   * PP_ERROR_INPROGRESS will be returned if there is another operation pending.
   */
  public static int SetLength ( PPResource file_io,
                                long length,
                                PPCompletionCallback callback)
  {
  	return _SetLength (file_io, length, callback);
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_FileIO_Flush")]
  extern static int _Flush ( PPResource file_io,
                             PPCompletionCallback callback);

  /**
   * Flush() flushes changes to disk.  This call can be very expensive! The
   * FileIO object must have been opened with write access and there must be no
   * other operations pending.
   *
   * @param[in] file_io A <code>PP_Resource</code> corresponding to a file
   * FileIO.
   * @param[in] callback A <code>PP_CompletionCallback</code> to be called upon
   * completion of Flush().
   *
   * @return An int32_t containing an error code from <code>pp_errors.h</code>.
   * PP_ERROR_FAILED will be returned if the file isn't opened, and
   * PP_ERROR_INPROGRESS will be returned if there is another operation pending.
   */
  public static int Flush ( PPResource file_io,  PPCompletionCallback callback)
  {
  	return _Flush (file_io, callback);
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_FileIO_Close")]
  extern static void _Close ( PPResource file_io);

  /**
   * Close() cancels any IO that may be pending, and closes the FileIO object.
   * Any pending callbacks will still run, reporting
   * <code>PP_ERROR_ABORTED</code> if pending IO was interrupted.  It is not
   * valid to call Open() again after a call to this method.
   * <strong>Note:</strong> If the FileIO object is destroyed, and it is still
   * open, then it will be implicitly closed, so you are not required to call
   * Close().
   *
   * @param[in] file_io A <code>PP_Resource</code> corresponding to a file
   * FileIO.
   */
  public static void Close ( PPResource file_io)
  {
  	 _Close (file_io);
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_FileIO_ReadToArray")]
  extern static int _ReadToArray ( PPResource file_io,
                                   long offset,
                                   int max_read_length,
                                   ref PPArrayOutput output,
                                   PPCompletionCallback callback);

  /**
   * ReadToArray() reads from an offset in the file.  A PP_ArrayOutput must be
   * provided so that output will be stored in its allocated buffer.  This
   * function might perform a partial read. The FileIO object must have been
   * opened with read access.
   *
   * @param[in] file_io A <code>PP_Resource</code> corresponding to a file
   * FileIO.
   * @param[in] offset The offset into the file.
   * @param[in] max_read_length The maximum number of bytes to read from
   * <code>offset</code>.
   * @param[in] output A <code>PP_ArrayOutput</code> to hold the output data.
   * @param[in] callback A <code>PP_CompletionCallback</code> to be called upon
   * completion of ReadToArray().
   *
   * @return The number of bytes read or an error code from
   * <code>pp_errors.h</code>. If the return value is 0, then end-of-file was
   * reached. It is valid to call ReadToArray() multiple times with a completion
   * callback to queue up parallel reads from the file, but pending reads
   * cannot be interleaved with other operations.
   */
  public static int ReadToArray ( PPResource file_io,
                                  long offset,
                                  int max_read_length,
                                  ref PPArrayOutput output,
                                  PPCompletionCallback callback)
  {
  	return _ReadToArray (file_io,
                        offset,
                        max_read_length,
                         ref output,
                        callback);
  }


}
/**
 * @}
 */


}
