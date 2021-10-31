using System;
using System.Runtime.InteropServices;
using System.Text;


public class GPIB 
{
	public enum ibsta_bit_numbers
	{
		DCAS_NUM = 0,
		DTAS_NUM = 1,
		LACS_NUM = 2,
		TACS_NUM = 3,
		ATN_NUM = 4,
		CIC_NUM = 5,
		REM_NUM = 6,
		LOK_NUM = 7,
		CMPL_NUM = 8,
		EVENT_NUM = 9,
		SPOLL_NUM = 10,
		RQS_NUM = 11,
		SRQI_NUM = 12,
		END_NUM = 13,
		TIMO_NUM = 14,
		ERR_NUM = 15
	};

	/* IBSTA status bits (returned by all functions) */
	public enum ibsta_bits
	{
		DCAS = ( 1 << ibsta_bit_numbers.DCAS_NUM ),	/* device clear state */
		DTAS = ( 1 << ibsta_bit_numbers.DTAS_NUM ),	/* device trigger state */
		LACS = ( 1 <<  ibsta_bit_numbers.LACS_NUM ),	/* GPIB interface is addressed as Listener */
		TACS = ( 1 <<  ibsta_bit_numbers.TACS_NUM ),	/* GPIB interface is addressed as Talker */
		ATN = ( 1 <<  ibsta_bit_numbers.ATN_NUM ),	/* Attention is asserted */
		CIC = ( 1 <<  ibsta_bit_numbers.CIC_NUM ),	/* GPIB interface is Controller-in-Charge */
		REM = ( 1 << ibsta_bit_numbers.REM_NUM ),	/* remote state */
		LOK = ( 1 << ibsta_bit_numbers.LOK_NUM ),	/* lockout state */
		CMPL = ( 1 <<  ibsta_bit_numbers.CMPL_NUM ),	/* I/O is complete  */
		EVENT = ( 1 << ibsta_bit_numbers.EVENT_NUM ),	/* DCAS, DTAS, or IFC has occurred */
		SPOLL = ( 1 << ibsta_bit_numbers.SPOLL_NUM ),	/* board serial polled by busmaster */
		RQS = ( 1 <<  ibsta_bit_numbers.RQS_NUM ),	/* Device requesting service  */
		SRQI = ( 1 << ibsta_bit_numbers.SRQI_NUM ),	/* SRQ is asserted */
		END = ( 1 << ibsta_bit_numbers.END_NUM ),	/* EOI or EOS encountered */
		TIMO = ( 1 << ibsta_bit_numbers.TIMO_NUM ),	/* Time limit on I/O or wait function exceeded */
		ERR = ( 1 << ibsta_bit_numbers.ERR_NUM )	/* Function call terminated on error */
	};
	/* IBERR error codes */
	public enum iberr_code
	{
		EDVR = 0,		/* system error */
		ECIC = 1,	/* not CIC */
		ENOL = 2,		/* no listeners */
		EADR = 3,		/* CIC and not addressed before I/O */
		EARG = 4,		/* bad argument to function call */
		ESAC = 5,		/* not SAC */
		EABO = 6,		/* I/O operation was aborted */
		ENEB = 7,		/* non-existent board (GPIB interface offline) */
		EDMA = 8,		/* DMA hardware error detected */
		EOIP = 10,		/* new I/O attempted with old I/O in progress  */
		ECAP = 11,		/* no capability for intended opeation */
		EFSO = 12,		/* file system operation error */
		EBUS = 14,		/* bus error */
		ESTB = 15,		/* lost serial poll bytes */
		ESRQ = 16,		/* SRQ stuck on */
		ETAB = 20              /* Table Overflow */
	};
	/* Timeout values and meanings */

	public enum gpib_timeout
	{
		TNONE = 0,		/* Infinite timeout (disabled)     */
		T10us = 1,		/* Timeout of 10 usec (ideal)      */
		T30us = 2,		/* Timeout of 30 usec (ideal)      */
		T100us = 3,		/* Timeout of 100 usec (ideal)     */
		T300us = 4,		/* Timeout of 300 usec (ideal)     */
		T1ms = 5,		/* Timeout of 1 msec (ideal)       */
		T3ms = 6,		/* Timeout of 3 msec (ideal)       */
		T10ms = 7,		/* Timeout of 10 msec (ideal)      */
		T30ms = 8,		/* Timeout of 30 msec (ideal)      */
		T100ms = 9,		/* Timeout of 100 msec (ideal)     */
		T300ms = 10,	/* Timeout of 300 msec (ideal)     */
		T1s = 11,		/* Timeout of 1 sec (ideal)        */
		T3s = 12,		/* Timeout of 3 sec (ideal)        */
		T10s = 13,		/* Timeout of 10 sec (ideal)       */
		T30s = 14,		/* Timeout of 30 sec (ideal)       */
		T100s = 15,		/* Timeout of 100 sec (ideal)      */
		T300s = 16,		/* Timeout of 300 sec (ideal)      */
		T1000s = 17		/* Timeout of 1000 sec (maximum)   */
	};

	/* End-of-string (EOS) modes for use with ibeos */

	public enum eos_flags
	{
		EOS_MASK = 0x1c00,
		REOS = 0x0400,		/* Terminate reads on EOS	*/
		XEOS = 0x800,	/* assert EOI when EOS char is sent */
		BIN = 0x1000		/* Do 8-bit compare on EOS	*/
	};

	/* GPIB Bus Control Lines bit vector */
	public enum bus_control_line
	{
		ValidDAV = 0x01,
		ValidNDAC = 0x02,
		ValidNRFD = 0x04,
		ValidIFC = 0x08,
		ValidREN = 0x10,
		ValidSRQ = 0x20,
		ValidATN = 0x40,
		ValidEOI = 0x80,
		ValidALL = 0xff,
		BusDAV = 0x0100,		/* DAV  line status bit */
		BusNDAC = 0x0200,		/* NDAC line status bit */
		BusNRFD = 0x0400,		/* NRFD line status bit */
		BusIFC = 0x0800,		/* IFC  line status bit */
		BusREN = 0x1000,		/* REN  line status bit */
		BusSRQ = 0x2000,		/* SRQ  line status bit */
		BusATN = 0x4000,		/* ATN  line status bit */
		BusEOI = 0x8000		/* EOI  line status bit */
	};


	public const int gpib_addr_max = 30;	/* max address for primary/secondary gpib addresses */

	public enum ibask_option
	{
		IbaPAD = 0x1,
		IbaSAD = 0x2,
		IbaTMO = 0x3,
		IbaEOT = 0x4,
		IbaPPC = 0x5,	/* board only */
		IbaREADDR = 0x6,	/* device only */
		IbaAUTOPOLL = 0x7,	/* board only */
		IbaCICPROT = 0x8,	/* board only */
		IbaIRQ = 0x9,	/* board only */
		IbaSC = 0xa,	/* board only */
		IbaSRE = 0xb,	/* board only */
		IbaEOSrd = 0xc,
		IbaEOSwrt = 0xd,
		IbaEOScmp = 0xe,
		IbaEOSchar = 0xf,
		IbaPP2 = 0x10,	/* board only */
		IbaTIMING = 0x11,	/* board only */
		IbaDMA = 0x12,	/* board only */
		IbaReadAdjust = 0x13,
		IbaWriteAdjust = 0x14,
		IbaEventQueue = 0x15,	/* board only */
		IbaSPollBit = 0x16,	/* board only */
		IbaSpollBit = 0x16,	/* board only */
		IbaSendLLO = 0x17,	/* board only */
		IbaSPollTime = 0x18,	/* device only */
		IbaPPollTime = 0x19,	/* board only */
		IbaEndBitIsNormal = 0x1a,
		IbaUnAddr = 0x1b,	/* device only */
		IbaHSCableLength = 0x1f,	/* board only */
		IbaIst = 0x20,	/* board only */
		IbaRsv = 0x21,	/* board only */
		IbaBNA = 0x200,	/* device only */
		IbaBaseAddr	= 0x201	/* GPIB board's base I/O address.*/
	};

	public enum ibconfig_option
	{
		IbcPAD = 0x1,
		IbcSAD = 0x2,
		IbcTMO = 0x3,
		IbcEOT = 0x4,
		IbcPPC = 0x5,	/* board only */
		IbcREADDR = 0x6,	/* device only */
		IbcAUTOPOLL = 0x7,	/* board only */
		IbcCICPROT = 0x8,	/* board only */
		IbcIRQ = 0x9,	/* board only */
		IbcSC = 0xa,	/* board only */
		IbcSRE = 0xb,	/* board only */
		IbcEOSrd = 0xc,
		IbcEOSwrt = 0xd,
		IbcEOScmp = 0xe,
		IbcEOSchar = 0xf,
		IbcPP2 = 0x10,	/* board only */
		IbcTIMING = 0x11,	/* board only */
		IbcDMA = 0x12,	/* board only */
		IbcReadAdjust = 0x13,
		IbcWriteAdjust = 0x14,
		IbcEventQueue = 0x15,	/* board only */
		IbcSPollBit = 0x16,	/* board only */
		IbcSpollBit = 0x16,	/* board only */
		IbcSendLLO = 0x17,	/* board only */
		IbcSPollTime = 0x18,	/* device only */
		IbcPPollTime = 0x19,	/* board only */
		IbcEndBitIsNormal = 0x1a,
		IbcUnAddr = 0x1b,	/* device only */
		IbcHSCableLength = 0x1f,	/* board only */
		IbcIst = 0x20,	/* board only */
		IbcRsv = 0x21,	/* board only */
		IbcLON = 0x22,
		IbcBNA = 0x200	/* device only */
	};

	public enum t1_delays
	{
		T1_DELAY_2000ns = 1,
		T1_DELAY_500ns = 2,
		T1_DELAY_350ns = 3
	};
	//	typedef ushort Addr4882_t;
//	typedef int  ssize_t;
//	typedef uint  size_t;
	public const ushort NOADDR = 0xffff;

    public const int STOPend = 0x100;

    public enum sad_special_address
    {
        NO_SAD = 0,
        ALL_SAD = -1
    };

    public enum send_eotmode
    {
        NULLend = 0,
        DABend = 2,
        NLend = 1
    };


	/*  IEEE 488 Function Prototypes  */
	[DllImport("Gpib-32.dll")]
	public static extern int ibask( int ud, int option,  out int value );
	[DllImport("Gpib-32.dll")]
	public static extern int ibbna( int ud, [MarshalAs(UnmanagedType.LPStr)] string board_name );
	[DllImport("Gpib-32.dll")]
	public static extern int ibcac( int ud, int synchronous );
	[DllImport("Gpib-32.dll")]
	public static extern int ibclr( int ud );
	
	[DllImport("Gpib-32.dll")]
	public static extern int ibcmd( int ud, [MarshalAs(UnmanagedType.LPStr)] string cmd, int cnt );
	[DllImport("Gpib-32.dll")]
	public static extern int ibcmd( int ud, IntPtr cmd, int cnt );	
	[DllImport("Gpib-32.dll")]
	public static extern int ibcmd( int ud, byte[] cmd, int cnt );	
	[DllImport("Gpib-32.dll")]
	public static extern int ibcmd( int ud, short[] cmd, int cnt );	
	[DllImport("Gpib-32.dll")]
	public static extern int ibcmd( int ud, int[] cmd, int cnt );	
	
	[DllImport("Gpib-32.dll")]
	public static extern int ibcmda( int ud, [MarshalAs(UnmanagedType.LPStr)] string cmd, int cnt );
	[DllImport("Gpib-32.dll")]
	public static extern int ibcmda( int ud, IntPtr cmd, int cnt );		
	[DllImport("Gpib-32.dll")]
	public static extern int ibcmda( int ud, byte[] cmd, int cnt );	
	[DllImport("Gpib-32.dll")]
	public static extern int ibcmda( int ud, short[] cmd, int cnt );	
	[DllImport("Gpib-32.dll")]
	public static extern int ibcmda( int ud, int[] cmd, int cnt );	
	
	[DllImport("Gpib-32.dll")]
	public static extern int ibconfig( int ud, int option, int value );
	[DllImport("Gpib-32.dll")]
	public static extern int ibdev( int board_index, int pad, int sad, int timo, int send_eoi, int eosmode );
	[DllImport("Gpib-32.dll")]
	public static extern int ibdma( int ud, int v );
	[DllImport("Gpib-32.dll")]
	public static extern int ibeot( int ud, int v );
	[DllImport("Gpib-32.dll")]
	public static extern int ibeos( int ud, int v );
	[DllImport("Gpib-32.dll")]
	public static extern int ibfind( [MarshalAs(UnmanagedType.LPStr)] string dev );
	[DllImport("Gpib-32.dll")]
	public static extern int ibgts(int ud, int shadow_handshake);
	[DllImport("Gpib-32.dll")]
	public static extern int ibist( int ud, int ist );
	[DllImport("Gpib-32.dll")]
	public static extern int iblines( int ud, out short line_status );
	[DllImport("Gpib-32.dll")]
	public static extern int ibln( int ud, int pad, int sad, out short found_listener );
	[DllImport("Gpib-32.dll")]
	public static extern int ibloc( int ud );
	[DllImport("Gpib-32.dll")]
	public static extern int ibonl( int ud, int onl );
	[DllImport("Gpib-32.dll")]
	public static extern int ibpad( int ud, int v );
	[DllImport("Gpib-32.dll")]
	public static extern int ibpct( int ud );
	[DllImport("Gpib-32.dll")]
	public static extern int ibppc( int ud, int v );
	[DllImport("Gpib-32.dll")]
        public static extern int ibrd(int ud, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int count);
	[DllImport("Gpib-32.dll")]
        public static extern int ibrd(int ud, IntPtr buf, int count);
	[DllImport("Gpib-32.dll")]
        public static extern int ibrd(int ud, byte[] buf, int count);
	[DllImport("Gpib-32.dll")]
        public static extern int ibrd(int ud, short[] buf, int count);
	[DllImport("Gpib-32.dll")]
        public static extern int ibrd(int ud, int[] buf, int count);
	[DllImport("Gpib-32.dll")]
        public static extern int ibrd(int ud, float[] buf, int count);
	[DllImport("Gpib-32.dll")]
        public static extern int ibrd(int ud, double[] buf, int count);
        
	[DllImport("Gpib-32.dll")]
	public static extern int ibrda( int ud, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int count );
	[DllImport("Gpib-32.dll")]
	public static extern int ibrda( int ud, IntPtr buf, int count );
	[DllImport("Gpib-32.dll")]
        public static extern int ibrda(int ud, byte[] buf, int count);
	[DllImport("Gpib-32.dll")]
        public static extern int ibrda(int ud, short[] buf, int count);
	[DllImport("Gpib-32.dll")]
        public static extern int ibrda(int ud, int[] buf, int count);
	[DllImport("Gpib-32.dll")]
        public static extern int ibrda(int ud, float[] buf, int count);
	[DllImport("Gpib-32.dll")]
        public static extern int ibrda(int ud, double[] buf, int count);
	
	[DllImport("Gpib-32.dll")]
	public static extern int ibrdf( int ud, string file_path );
	[DllImport("Gpib-32.dll")]
	public static extern int ibrpp( int ud, out byte ppr );
	[DllImport("Gpib-32.dll")]
	public static extern int ibrsc( int ud, int v );
	[DllImport("Gpib-32.dll")]
	public static extern int ibrsp( int ud, out byte spr );
	[DllImport("Gpib-32.dll")]
	public static extern int ibrsv( int ud, int v );
	[DllImport("Gpib-32.dll")]
	public static extern int ibsad( int ud, int v );
	[DllImport("Gpib-32.dll")]
	public static extern int ibsic( int ud );
	[DllImport("Gpib-32.dll")]
	public static extern int ibsre( int ud, int v );
	[DllImport("Gpib-32.dll")]
	public static extern int ibstop( int ud );
	[DllImport("Gpib-32.dll")]
	public static extern int ibtmo( int ud, int v );
	[DllImport("Gpib-32.dll")]
	public static extern int ibtrg( int ud );
	[DllImport("Gpib-32.dll")]
	public static extern int ibwait( int ud, int mask );
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrt( int ud, [MarshalAs(UnmanagedType.LPStr)] string buf, int count );
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrt( int ud, IntPtr buf, int count );
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrt( int ud, byte[] buf, int count );
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrt( int ud, short[] buf, int count );
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrt( int ud, int[] buf, int count );
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrt( int ud, float[] buf, int count );
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrt( int ud, double[] buf, int count );
	
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrta( int ud, [MarshalAs(UnmanagedType.LPStr)] string buf, int count );
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrta( int ud, IntPtr buf, int count );
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrta( int ud, byte[] buf, int count );
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrta( int ud, short[] buf, int count );
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrta( int ud, int[] buf, int count );
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrta( int ud, float[] buf, int count );
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrta( int ud, double[] buf, int count );
		
	[DllImport("Gpib-32.dll")]
	public static extern int ibwrtf( int ud, [MarshalAs(UnmanagedType.LPStr)] string file_path );

	[DllImport("Gpib-32.dll")]
	public static extern int gpib_get_globals (out int pibsta, out int piberr, out int pibcnt, out int pibcntl);
	
	/*  IEEE 488.2 Function Prototypes  */
	[DllImport("Gpib-32.dll")]
	public static extern void AllSPoll( int board_desc, ushort[] addressList, ushort[] resultList );
	[DllImport("Gpib-32.dll")]
	public static extern void AllSpoll( int board_desc, ushort[] addressLis, ushort[] resultList );
	[DllImport("Gpib-32.dll")]
	public static extern void DevClear( int board_desc, ushort address );
	[DllImport("Gpib-32.dll")]
	public static extern void DevClearList( int board_desc, ushort[] addressLis );
	[DllImport("Gpib-32.dll")]
	public static extern void EnableLocal( int board_desc, ushort[] addressLis );
	[DllImport("Gpib-32.dll")]
	public static extern void EnableRemote( int board_desc, ushort[] addressLis );
	[DllImport("Gpib-32.dll")]
	public static extern void FindLstn( int board_desc,  ushort[] padList, ushort[] resultList, int maxNumResults );
	[DllImport("Gpib-32.dll")]
	public static extern void FindRQS( int board_desc, ushort[] addressList, out short result );
	[DllImport("Gpib-32.dll")]
	public static extern void PassControl( int board_desc, ushort address );
	[DllImport("Gpib-32.dll")]
	public static extern void PPoll( int board_desc, out short result );
	[DllImport("Gpib-32.dll")]
	public static extern void PPollConfig( int board_desc, ushort address, int dataLine, int lineSense );
	[DllImport("Gpib-32.dll")]
	public static extern void PPollUnconfig( int board_desc, ushort[] addressList );
	[DllImport("Gpib-32.dll")]
	public static extern void RcvRespMsg( int board_desc, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer, int count, int termination );
	[DllImport("Gpib-32.dll")]
	public static extern void RcvRespMsg( int board_desc, IntPtr buffer, int count, int termination );
	[DllImport("Gpib-32.dll")]
	public static extern void RcvRespMsg( int board_desc, byte[] buffer, int count, int termination );
	[DllImport("Gpib-32.dll")]
	public static extern void RcvRespMsg( int board_desc, short[] buffer, int count, int termination );
	[DllImport("Gpib-32.dll")]
	public static extern void RcvRespMsg( int board_desc, int[] buffer, int count, int termination );
	[DllImport("Gpib-32.dll")]
	public static extern void RcvRespMsg( int board_desc, float[] buffer, int count, int termination );
	[DllImport("Gpib-32.dll")]
	public static extern void RcvRespMsg( int board_desc, double[] buffer, int count, int termination );
		
	[DllImport("Gpib-32.dll")]
	public static extern void ReadStatusByte( int board_desc, ushort address, out short result );
	
	[DllImport("Gpib-32.dll")]
	public static extern void Receive( int board_desc, ushort address, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer, int count, int termination );
	[DllImport("Gpib-32.dll")]
	public static extern void Receive( int board_desc, ushort address, IntPtr buffer, int count, int termination );
	[DllImport("Gpib-32.dll")]
	public static extern void Receive( int board_desc, ushort address,  byte[] buffer, int count, int termination );
	[DllImport("Gpib-32.dll")]
	public static extern void Receive( int board_desc, ushort address,  short[] buffer, int count, int termination );
	[DllImport("Gpib-32.dll")]
	public static extern void Receive( int board_desc, ushort address,  int[] buffer, int count, int termination );
	[DllImport("Gpib-32.dll")]
	public static extern void Receive( int board_desc, ushort address,  float[] buffer, int count, int termination );
	[DllImport("Gpib-32.dll")]
	public static extern void Receive( int board_desc, ushort address,  double[] buffer, int count, int termination );
	
	
	[DllImport("Gpib-32.dll")]
	public static extern void ReceiveSetup( int board_desc, ushort address );
	[DllImport("Gpib-32.dll")]
	public static extern void ResetSys( int board_desc, ushort[] addressList );
	[DllImport("Gpib-32.dll")]
	public static extern void Send( int board_desc, ushort address, [MarshalAs(UnmanagedType.LPStr)] string buffer,	int count, int eot_mode );
	[DllImport("Gpib-32.dll")]
	public static extern void Send( int board_desc, ushort address, IntPtr buffer,	int count, int eot_mode );
	[DllImport("Gpib-32.dll")]
	public static extern void Send( int board_desc, ushort address, byte[] buffer,	int count, int eot_mode );
	[DllImport("Gpib-32.dll")]
	public static extern void Send( int board_desc, ushort address, short[] buffer,	int count, int eot_mode );
	[DllImport("Gpib-32.dll")]
	public static extern void Send( int board_desc, ushort address, int[] buffer,	int count, int eot_mode );
	[DllImport("Gpib-32.dll")]
	public static extern void Send( int board_desc, ushort address, float[] buffer,	int count, int eot_mode );
	[DllImport("Gpib-32.dll")]
	public static extern void Send( int board_desc, ushort address, double[] buffer, int count, int eot_mode );
	
	[DllImport("Gpib-32.dll")]
	public static extern void SendCmds( int board_desc, [MarshalAs(UnmanagedType.LPStr)] string cmds, int count );
	[DllImport("Gpib-32.dll")]
	public static extern void SendCmds( int board_desc, IntPtr cmds, int count );
	[DllImport("Gpib-32.dll")]
	public static extern void SendCmds( int board_desc, byte[] cmds, int count );
	[DllImport("Gpib-32.dll")]
	public static extern void SendCmds( int board_desc, short[] cmds, int count );
	[DllImport("Gpib-32.dll")]
	public static extern void SendCmds( int board_desc, int[] cmds, int count );
	[DllImport("Gpib-32.dll")]
	public static extern void SendCmds( int board_desc, float[] cmds, int count );
	[DllImport("Gpib-32.dll")]
	public static extern void SendCmds( int board_desc, double[]cmds, int count );
	
	[DllImport("Gpib-32.dll")]
	public static extern void SendDataBytes( int board_desc, [MarshalAs(UnmanagedType.LPStr)] string buffer, int count, int eotmode );
	[DllImport("Gpib-32.dll")]
	public static extern void SendDataBytes( int board_desc, IntPtr buffer, int count, int eotmode );
	[DllImport("Gpib-32.dll")]
	public static extern void SendDataBytes( int board_desc, byte[] buffer, int count, int eotmode );
	[DllImport("Gpib-32.dll")]
	public static extern void SendDataBytes( int board_desc, short[] buffer, int count, int eotmode );
	[DllImport("Gpib-32.dll")]
	public static extern void SendDataBytes( int board_desc, int[] buffer, int count, int eotmode );
	[DllImport("Gpib-32.dll")]
	public static extern void SendDataBytes( int board_desc, float[] buffer, int count, int eotmode );
	[DllImport("Gpib-32.dll")]
	public static extern void SendDataBytes( int board_desc, double[] buffer, int count, int eotmode );
	
	[DllImport("Gpib-32.dll")]
	public static extern void SendIFC( int board_desc );
	[DllImport("Gpib-32.dll")]
	public static extern void SendLLO( int board_desc );
	[DllImport("Gpib-32.dll")]
	public static extern void SendList( int board_desc, ushort[] addressList, [MarshalAs(UnmanagedType.LPStr)] string buffer, int count, int eotmode );
	[DllImport("Gpib-32.dll")]
	public static extern void SendList( int board_desc, ushort[] addressList, IntPtr buffer, int count, int eotmode );	
	[DllImport("Gpib-32.dll")]
	public static extern void SendList( int board_desc, ushort[] addressList, byte[] buffer, int count, int eotmode );	
	[DllImport("Gpib-32.dll")]
	public static extern void SendList( int board_desc, ushort[] addressList, short[] buffer, int count, int eotmode );	
	[DllImport("Gpib-32.dll")]
	public static extern void SendList( int board_desc, ushort[] addressList, int[] buffer, int count, int eotmode );	
	[DllImport("Gpib-32.dll")]
	public static extern void SendList( int board_desc, ushort[] addressList, float[] buffer, int count, int eotmode );	
	[DllImport("Gpib-32.dll")]
	public static extern void SendList( int board_desc, ushort[] addressList, double[] buffer, int count, int eotmode );	
	
	[DllImport("Gpib-32.dll")]
	public static extern void SendSetup( int board_desc, ushort[] addressList );
	[DllImport("Gpib-32.dll")]
	public static extern void SetRWLS( int board_desc, ushort[] addressList );
	[DllImport("Gpib-32.dll")]
	public static extern void TestSRQ( int board_desc, out short result );
	[DllImport("Gpib-32.dll")]
	public static extern void TestSys( int board_desc, ushort[] addrlist, short[] resultList );
	[DllImport("Gpib-32.dll")]
	public static extern void Trigger( int board_desc, ushort address );
	[DllImport("Gpib-32.dll")]
	public static extern void TriggerList( int board_desc, ushort[] addressList );
	[DllImport("Gpib-32.dll")]
	public static extern void WaitSRQ( int board_desc, out short result );

}