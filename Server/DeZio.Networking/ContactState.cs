// (C) 2013 - Dennis Ziolkowski
// Server : ContactState.cs

namespace DeZio.Networking {

    /// <summary>
    /// Contact states
    /// </summary>
    public enum ContactState {
        /// <summary>
        /// Is online
        /// </summary>
        Online = 1,
        /// <summary>
        /// Does not exist
        /// </summary>
        NonExist = -1,
        /// <summary>
        /// Is offline
        /// </summary>
        Offline = 0
    }
}