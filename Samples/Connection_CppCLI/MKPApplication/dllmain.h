// dllmain.h : Declaration of module class.

class CMKPApplicationModule : public ATL::CAtlDllModuleT< CMKPApplicationModule >
{
public :
	DECLARE_LIBID(LIBID_MKPApplicationLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_MKPAPPLICATION, "{6ED0D595-BB7E-485D-B16B-D3BCFCCA43C8}")
};

extern class CMKPApplicationModule _AtlModule;
