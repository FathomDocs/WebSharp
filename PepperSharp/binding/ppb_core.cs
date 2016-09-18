/* Copyright (c) 2016 Xamarin. */

/* NOTE: this is auto-generated from IDL */
/* From ppb_core.idl modified Thu May 12 07:00:02 2016. */

using System;
using System.Runtime.InteropServices;

namespace PepperSharp {


/**
 * @file
 * This file defines the <code>PPB_Core</code> interface defined by the browser
 * and containing pointers to functions related to memory management, time, and
 * threads.
 */


/**
 * @addtogroup Interfaces
 * @{
 */
/**
 * The <code>PPB_Core</code> interface contains pointers to functions related
 * to memory management, time, and threads on the browser.
 *
 */
internal static partial class PPBCore {
  [DllImport("PepperPlugin", EntryPoint = "PPB_Core_AddRefResource")]
  extern static void _AddRefResource ( PPResource resource);

  /**
   *
   * AddRefResource() adds a reference to a resource.
   *
   * @param[in] config A <code>PP_Resource</code> corresponding to a
   * resource.
   */
  public static void AddRefResource ( PPResource resource)
  {
  	 _AddRefResource (resource);
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_Core_ReleaseResource")]
  extern static void _ReleaseResource ( PPResource resource);

  /**
   * ReleaseResource() removes a reference from a resource.
   *
   * @param[in] config A <code>PP_Resource</code> corresponding to a
   * resource.
   */
  public static void ReleaseResource ( PPResource resource)
  {
  	 _ReleaseResource (resource);
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_Core_GetTime")]
  extern static double _GetTime ();

  /**
   * GetTime() returns the "wall clock time" according to the
   * browser.
   *
   * @return A <code>PP_Time</code> containing the "wall clock time" according
   * to the browser.
   */
  public static double GetTime ()
  {
  	return _GetTime ();
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_Core_GetTimeTicks")]
  extern static double _GetTimeTicks ();

  /**
   * GetTimeTicks() returns the "tick time" according to the browser.
   * This clock is used by the browser when passing some event times to the
   * module (e.g. using the <code>PP_InputEvent::time_stamp_seconds</code>
   * field). It is not correlated to any actual wall clock time
   * (like GetTime()). Because of this, it will not run change if the user
   * changes their computer clock.
   *
   * @return A <code>PP_TimeTicks</code> containing the "tick time" according
   * to the browser.
   */
  public static double GetTimeTicks ()
  {
  	return _GetTimeTicks ();
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_Core_CallOnMainThread")]
  extern static void _CallOnMainThread ( int delay_in_milliseconds,
                                         PPCompletionCallback callback,
                                         int result);

  /**
   * CallOnMainThread() schedules work to be executed on the main module thread
   * after the specified delay. The delay may be 0 to specify a call back as
   * soon as possible.
   *
   * The <code>result</code> parameter will just be passed as the second
   * argument to the callback. Many applications won't need this, but it allows
   * a module to emulate calls of some callbacks which do use this value.
   *
   * <strong>Note:</strong> CallOnMainThread, even when used from the main
   * thread with a delay of 0 milliseconds, will never directly invoke the
   * callback.  Even in this case, the callback will be scheduled
   * asynchronously.
   *
   * <strong>Note:</strong> If the browser is shutting down or if the module
   * has no instances, then the callback function may not be called.
   *
   * @param[in] delay_in_milliseconds An int32_t delay in milliseconds.
   * @param[in] callback A <code>PP_CompletionCallback</code> callback function
   * that the browser will call after the specified delay.
   * @param[in] result An int32_t that the browser will pass to the given
   * <code>PP_CompletionCallback</code>.
   */
  public static void CallOnMainThread ( int delay_in_milliseconds,
                                        PPCompletionCallback callback,
                                        int result)
  {
  	 _CallOnMainThread (delay_in_milliseconds, callback, result);
  }


  [DllImport("PepperPlugin", EntryPoint = "PPB_Core_IsMainThread")]
  extern static PPBool _IsMainThread ();

  /**
   * IsMainThread() returns true if the current thread is the main pepper
   * thread.
   *
   * This function is useful for implementing sanity checks, and deciding if
   * dispatching using CallOnMainThread() is required.
   *
   * @return A <code>PP_Bool</code> containing <code>PP_TRUE</code> if the
   * current thread is the main pepper thread, otherwise <code>PP_FALSE</code>.
   */
  public static PPBool IsMainThread ()
  {
  	return _IsMainThread ();
  }


}
/**
 * @}
 */


}
