

using System;

namespace IdeaRS.SimpleStructModel
{
    /// <summary>
    /// PSC Cell cross-section - base
    /// </summary>
  public partial class CellBase: SimpleElementBase
  {
    /// <summary>
    /// gets, sets height of top slab
    /// </summary>
    public System.Double HOut1 {get; set;}

    /// <summary>
    /// gets, sets height of total top slab flange
    /// </summary>
    public System.Double HOut2 {get; set;}

    /// <summary>
    /// gets, sets height of top slab flange - top flange
    /// </summary>
    public System.Double HOut21 {get; set;}

    /// <summary>
    /// gets, sets height of top slab flange - bottom flange
    /// </summary>
    public System.Double HOut22 {get; set;}

    /// <summary>
    /// gets, sets height of h out 3
    /// </summary>
    public System.Double HOut3 {get; set;}

    /// <summary>
    /// gets, sets height of bottom flange
    /// </summary>
    public System.Double HOut31 {get; set;}

    /// <summary>
    /// gets, sets width of total top flange
    /// </summary>
    public System.Double BOut1 {get; set;}

    /// <summary>
    /// gets, sets width of top flange - point JO1
    /// </summary>
    public System.Double BOut11 {get; set;}

    /// <summary>
    /// gets, sets width of top flange - point JO2
    /// </summary>
    public System.Double BOut12 {get; set;}

    /// <summary>
    /// gets, sets width of total bottom flange
    /// </summary>
    public System.Double BOut2 {get; set;}

    /// <summary>
    /// gets, sets dimension to point JO3
    /// </summary>
    public System.Double BOut21 {get; set;}

    /// <summary>
    /// gets, sets width of bottom part
    /// </summary>
    public System.Double BOut3 {get; set;}

    /// <summary>
    /// gets, sets height of top slab inner
    /// </summary>
    public System.Double HIn1 {get; set;}

    /// <summary>
    /// gets, sets height of top slab total flange - inner
    /// </summary>
    public System.Double HIn2 {get; set;}

    /// <summary>
    /// gets, sets height of top slab flange - point JI1
    /// </summary>
    public System.Double HIn21 {get; set;}

    /// <summary>
    /// gets, sets height of top slab flange - point JI2
    /// </summary>
    public System.Double HIn22 {get; set;}

    /// <summary>
    /// gets, sets height HI3
    /// </summary>
    public System.Double HIn3 {get; set;}

    /// <summary>
    /// gets, sets height HI31 for point JI3
    /// </summary>
    public System.Double HIn31 {get; set;}

    /// <summary>
    /// gets, sets height HI4
    /// </summary>
    public System.Double HIn4 {get; set;}

    /// <summary>
    /// gets, sets height HI41 for point JI5
    /// </summary>
    public System.Double HIn41 {get; set;}

    /// <summary>
    /// gets, sets height HI42 for point JI4
    /// </summary>
    public System.Double HIn42 {get; set;}

    /// <summary>
    /// gets, sets height HI5
    /// </summary>
    public System.Double HIn5 {get; set;}

    /// <summary>
    /// gets, sets height BI1
    /// </summary>
    public System.Double BIn1 {get; set;}

    /// <summary>
    /// gets, sets width BI11 for point JI1
    /// </summary>
    public System.Double BIn11 {get; set;}

    /// <summary>
    /// gets, sets width BI12 for point JI2
    /// </summary>
    public System.Double BIn12 {get; set;}

    /// <summary>
    /// gets, sets width BI21 for point JI3
    /// </summary>
    public System.Double BIn21 {get; set;}

    /// <summary>
    /// gets, sets height BI3
    /// </summary>
    public System.Double BIn3 {get; set;}

    /// <summary>
    /// gets, sets width BI31 for point JI5
    /// </summary>
    public System.Double BIn31 {get; set;}

    /// <summary>
    /// gets, sets width BI32 for point JI4
    /// </summary>
    public System.Double BIn32 {get; set;}

    /// <summary>
    /// gets, sets height BI4
    /// </summary>
    public System.Double BIn4 {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.CellBase,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.HOut1 = this.HOut1;
      dynamicDest.HOut2 = this.HOut2;
      dynamicDest.HOut21 = this.HOut21;
      dynamicDest.HOut22 = this.HOut22;
      dynamicDest.HOut3 = this.HOut3;
      dynamicDest.HOut31 = this.HOut31;
      dynamicDest.BOut1 = this.BOut1;
      dynamicDest.BOut11 = this.BOut11;
      dynamicDest.BOut12 = this.BOut12;
      dynamicDest.BOut2 = this.BOut2;
      dynamicDest.BOut21 = this.BOut21;
      dynamicDest.BOut3 = this.BOut3;
      dynamicDest.HIn1 = this.HIn1;
      dynamicDest.HIn2 = this.HIn2;
      dynamicDest.HIn21 = this.HIn21;
      dynamicDest.HIn22 = this.HIn22;
      dynamicDest.HIn3 = this.HIn3;
      dynamicDest.HIn31 = this.HIn31;
      dynamicDest.HIn4 = this.HIn4;
      dynamicDest.HIn41 = this.HIn41;
      dynamicDest.HIn42 = this.HIn42;
      dynamicDest.HIn5 = this.HIn5;
      dynamicDest.BIn1 = this.BIn1;
      dynamicDest.BIn11 = this.BIn11;
      dynamicDest.BIn12 = this.BIn12;
      dynamicDest.BIn21 = this.BIn21;
      dynamicDest.BIn3 = this.BIn3;
      dynamicDest.BIn31 = this.BIn31;
      dynamicDest.BIn32 = this.BIn32;
      dynamicDest.BIn4 = this.BIn4;
    }
  }
    /// <summary>
    /// CellOne
    /// </summary>
  public partial class CellOne: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.CellOne,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
    /// <summary>
    /// CellOne
    /// </summary>
  public partial class CellTwo: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.CellTwo,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
  public partial class ShapeOctagon: SimpleElementBase
  {
    /// <summary>
    /// Octagon height
    /// </summary>
    public System.Double Height {get; set;}

    /// <summary>
    /// Octagon width
    /// </summary>
    public System.Double Width {get; set;}

    /// <summary>
    /// Octagon horizontal decrease
    /// </summary>
    public System.Double Horizontal {get; set;}

    /// <summary>
    /// Octagon vertical decrease
    /// </summary>
    public System.Double Vertical {get; set;}

    /// <summary>
    /// Octagon wall thickness
    /// </summary>
    public System.Double Th {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeOctagon,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Height = this.Height;
      dynamicDest.Width = this.Width;
      dynamicDest.Horizontal = this.Horizontal;
      dynamicDest.Vertical = this.Vertical;
      dynamicDest.Th = this.Th;
    }
  }
  public partial class BeamShapeBox: SimpleElementBase
  {
    /// <summary>
    /// Width of Hollow cross-section
    /// </summary>
    public System.Double Bw {get; set;}

    /// <summary>
    /// Bottom width of opening of Hollow cross-section
    /// </summary>
    public System.Double Bw2 {get; set;}

    /// <summary>
    /// Top width of opening of Hollow cross-section
    /// </summary>
    public System.Double Bw3 {get; set;}

    /// <summary>
    /// Total depth of Hollow cross-section
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Depth of Hollow cross-section
    /// </summary>
    public System.Double H2 {get; set;}

    /// <summary>
    /// Horizontal dimension of indent of Hollow cross-section
    /// </summary>
    public System.Double C {get; set;}

    /// <summary>
    /// Vertical dimension of indent of Hollow cross-section
    /// </summary>
    public System.Double C2 {get; set;}

    /// <summary>
    /// Top width of Hollow cross-section
    /// </summary>
    public System.Double Bc {get; set;}

    /// <summary>
    /// Top flange haunch of Hollow cross-section
    /// </summary>
    public System.Double Htf {get; set;}

    /// <summary>
    /// Bottom slab thickness of Hollow cross-section
    /// </summary>
    public System.Double Hf {get; set;}

    /// <summary>
    /// Top flange thickness of Hollow cross-section
    /// </summary>
    public System.Double Hf2 {get; set;}

    /// <summary>
    /// Opening depth of Hollow cross-section
    /// </summary>
    public System.Double O {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.BeamShapeBox,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bw = this.Bw;
      dynamicDest.Bw2 = this.Bw2;
      dynamicDest.Bw3 = this.Bw3;
      dynamicDest.H = this.H;
      dynamicDest.H2 = this.H2;
      dynamicDest.C = this.C;
      dynamicDest.C2 = this.C2;
      dynamicDest.Bc = this.Bc;
      dynamicDest.Htf = this.Htf;
      dynamicDest.Hf = this.Hf;
      dynamicDest.Hf2 = this.Hf2;
      dynamicDest.O = this.O;
    }
  }
  public partial class BeamShapeBox1: SimpleElementBase
  {
    /// <summary>
    /// Width of Hollow cross-section
    /// </summary>
    public System.Double Bw {get; set;}

    /// <summary>
    /// Bottom width of opening of Hollow cross-section
    /// </summary>
    public System.Double Bw2 {get; set;}

    /// <summary>
    /// Top width of opening of Hollow cross-section
    /// </summary>
    public System.Double Bw3 {get; set;}

    /// <summary>
    /// Total depth of Hollow cross-section
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Depth of Hollow cross-section
    /// </summary>
    public System.Double H2 {get; set;}

    /// <summary>
    /// Horizontal dimension of indent of Hollow cross-section
    /// </summary>
    public System.Double C {get; set;}

    /// <summary>
    /// Vertical dimension of indent of Hollow cross-section
    /// </summary>
    public System.Double C2 {get; set;}

    /// <summary>
    /// Top width of Hollow cross-section
    /// </summary>
    public System.Double Bc {get; set;}

    /// <summary>
    /// Top flange haunch of Hollow cross-section
    /// </summary>
    public System.Double Htf {get; set;}

    /// <summary>
    /// Opening haunch of Hollow cross-section
    /// </summary>
    public System.Double Htf2 {get; set;}

    /// <summary>
    /// Bottom slab thickness of Hollow cross-section
    /// </summary>
    public System.Double Hf {get; set;}

    /// <summary>
    /// Top flange thickness of Hollow cross-section
    /// </summary>
    public System.Double Hf2 {get; set;}

    /// <summary>
    /// Opening depth of Hollow cross-section
    /// </summary>
    public System.Double O {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.BeamShapeBox1,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bw = this.Bw;
      dynamicDest.Bw2 = this.Bw2;
      dynamicDest.Bw3 = this.Bw3;
      dynamicDest.H = this.H;
      dynamicDest.H2 = this.H2;
      dynamicDest.C = this.C;
      dynamicDest.C2 = this.C2;
      dynamicDest.Bc = this.Bc;
      dynamicDest.Htf = this.Htf;
      dynamicDest.Htf2 = this.Htf2;
      dynamicDest.Hf = this.Hf;
      dynamicDest.Hf2 = this.Hf2;
      dynamicDest.O = this.O;
    }
  }
  public partial class BeamShapeIHaunchChamfer: SimpleElementBase
  {
    /// <summary>
    /// Width of bottom flange of I-shaped cross-section
    /// </summary>
    public System.Double Bbf {get; set;}

    /// <summary>
    /// Thickness of bottom flange of I-shaped cross-section
    /// </summary>
    public System.Double Hbf {get; set;}

    /// <summary>
    /// Thickness of bottom flange haunch of I-shaped cross-section
    /// </summary>
    public System.Double Hbfh {get; set;}

    /// <summary>
    /// Thickness of web of I-shaped cross-section
    /// </summary>
    public System.Double Bw {get; set;}

    /// <summary>
    /// Depth of I-shaped cross-section
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Thickness of top flange haunch of I-shaped cross-section
    /// </summary>
    public System.Double Htfh {get; set;}

    /// <summary>
    /// Thickness of top flange of I-shaped cross-section
    /// </summary>
    public System.Double Htf {get; set;}

    /// <summary>
    /// Width of top flange of I-shaped cross-section
    /// </summary>
    public System.Double Btf {get; set;}

    /// <summary>
    /// Web haunch of I-shaped cross-section
    /// </summary>
    public System.Double Bwh {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.BeamShapeIHaunchChamfer,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bbf = this.Bbf;
      dynamicDest.Hbf = this.Hbf;
      dynamicDest.Hbfh = this.Hbfh;
      dynamicDest.Bw = this.Bw;
      dynamicDest.H = this.H;
      dynamicDest.Htfh = this.Htfh;
      dynamicDest.Htf = this.Htf;
      dynamicDest.Btf = this.Btf;
      dynamicDest.Bwh = this.Bwh;
    }
  }
  public partial class BeamShapeIHaunchChamferAssym: SimpleElementBase
  {
    /// <summary>
    /// Width of bottom flange of Asymmetrical I-shaped cross-section
    /// </summary>
    public System.Double Bbf {get; set;}

    /// <summary>
    /// Thickness of bottom flange of Asymmetrical I-shaped cross-section
    /// </summary>
    public System.Double Hbf {get; set;}

    /// <summary>
    /// Thickness of bottom flange haunch of Asymmetrical I-shaped cross-section
    /// </summary>
    public System.Double Hbfh {get; set;}

    /// <summary>
    /// Thickness of web of Asymmetrical I-shaped cross-section
    /// </summary>
    public System.Double Bw {get; set;}

    /// <summary>
    /// Web haunch of Asymmetrical I-shaped cross-section
    /// </summary>
    public System.Double Bwh {get; set;}

    /// <summary>
    /// Depth of Asymmetrical I-shaped cross-section
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Thickness of top flange haunch of Asymmetrical I-shaped cross-section
    /// </summary>
    public System.Double Htfh {get; set;}

    /// <summary>
    /// Thickness of top flange of Asymmetrical I-shaped cross-section
    /// </summary>
    public System.Double Htf {get; set;}

    /// <summary>
    /// Width of top flange - left of Asymmetrical I-shaped cross-section
    /// </summary>
    public System.Double Btfl {get; set;}

    /// <summary>
    /// Width of top flange - right of Asymmetrical I-shaped cross-section
    /// </summary>
    public System.Double Btfr {get; set;}

    /// <summary>
    /// Width of top flange of Asymmetrical I-shaped cross-section
    /// </summary>
    public System.Double Btf {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.BeamShapeIHaunchChamferAssym,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bbf = this.Bbf;
      dynamicDest.Hbf = this.Hbf;
      dynamicDest.Hbfh = this.Hbfh;
      dynamicDest.Bw = this.Bw;
      dynamicDest.Bwh = this.Bwh;
      dynamicDest.H = this.H;
      dynamicDest.Htfh = this.Htfh;
      dynamicDest.Htf = this.Htf;
      dynamicDest.Btfl = this.Btfl;
      dynamicDest.Btfr = this.Btfr;
      dynamicDest.Btf = this.Btf;
    }
  }
  public partial class BeamShapeIrevDegen: SimpleElementBase
  {
    /// <summary>
    /// Bottom flange width of Inverted T-shaped cross-section
    /// </summary>
    public System.Double Bbf {get; set;}

    /// <summary>
    /// Web thickness of Inverted T-shaped cross-section
    /// </summary>
    public System.Double Bw {get; set;}

    /// <summary>
    /// Bottom flange thickness of Inverted T-shaped cross-section
    /// </summary>
    public System.Double Hbf {get; set;}

    /// <summary>
    /// Bottom flange haunch of Inverted T-shaped cross-section
    /// </summary>
    public System.Double Hbfh {get; set;}

    /// <summary>
    /// Depth of Inverted T-shaped cross-section
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Depth of web haunch of Inverted T-shaped cross-section
    /// </summary>
    public System.Double Htfh {get; set;}

    /// <summary>
    /// Top flange width of Inverted T-shaped cross-section
    /// </summary>
    public System.Double Btf {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.BeamShapeIrevDegen,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bbf = this.Bbf;
      dynamicDest.Bw = this.Bw;
      dynamicDest.Hbf = this.Hbf;
      dynamicDest.Hbfh = this.Hbfh;
      dynamicDest.H = this.H;
      dynamicDest.Htfh = this.Htfh;
      dynamicDest.Btf = this.Btf;
    }
  }
  public partial class BeamShapeIrevDegenAdd: SimpleElementBase
  {
    /// <summary>
    /// Bottom flange width of Cross-section
    /// </summary>
    public System.Double Bbf {get; set;}

    /// <summary>
    /// Web thickness of Cross-section
    /// </summary>
    public System.Double Bw {get; set;}

    /// <summary>
    /// Bottom flange thickness of Cross-section
    /// </summary>
    public System.Double Hbf {get; set;}

    /// <summary>
    /// Bottom flange haunch of Cross-section
    /// </summary>
    public System.Double Hbfh {get; set;}

    /// <summary>
    /// Depth of Cross-section
    /// </summary>
    public System.Double H2 {get; set;}

    /// <summary>
    /// Depth of web haunch of Cross-section
    /// </summary>
    public System.Double Htfh {get; set;}

    /// <summary>
    /// Total depth of Cross-section
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Thickness of slab of Cross-section
    /// </summary>
    public System.Double Hc {get; set;}

    /// <summary>
    /// Top width of web of Cross-section
    /// </summary>
    public System.Double Btf {get; set;}

    /// <summary>
    /// Left slab overhang of Cross-section
    /// </summary>
    public System.Double L {get; set;}

    /// <summary>
    /// Right slab overhang of Cross-section
    /// </summary>
    public System.Double R {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.BeamShapeIrevDegenAdd,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bbf = this.Bbf;
      dynamicDest.Bw = this.Bw;
      dynamicDest.Hbf = this.Hbf;
      dynamicDest.Hbfh = this.Hbfh;
      dynamicDest.H2 = this.H2;
      dynamicDest.Htfh = this.Htfh;
      dynamicDest.H = this.H;
      dynamicDest.Hc = this.Hc;
      dynamicDest.Btf = this.Btf;
      dynamicDest.L = this.L;
      dynamicDest.R = this.R;
    }
  }
  public partial class BeamShapeIZDegen: SimpleElementBase
  {
    /// <summary>
    /// Width of joint of Composite cross-section
    /// </summary>
    public System.Double Bn {get; set;}

    /// <summary>
    /// Length of bearing area of Composite cross-section
    /// </summary>
    public System.Double Bn3 {get; set;}

    /// <summary>
    /// Depth of formwork of Composite cross-section
    /// </summary>
    public System.Double Hn {get; set;}

    /// <summary>
    /// Left slab thickness of Composite cross-section
    /// </summary>
    public System.Double Hc {get; set;}

    /// <summary>
    /// Left slab overhang of Composite cross-section
    /// </summary>
    public System.Double L {get; set;}

    /// <summary>
    /// Depth of formwork of Composite cross-section
    /// </summary>
    public System.Double Hn2 {get; set;}

    /// <summary>
    /// Right slab thickness of Composite cross-section
    /// </summary>
    public System.Double Hc2 {get; set;}

    /// <summary>
    /// Thickness of Composite cross-section
    /// </summary>
    public System.Double Hc3 {get; set;}

    /// <summary>
    /// Right slab overhang of Composite cross-section
    /// </summary>
    public System.Double R {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.BeamShapeIZDegen,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bn = this.Bn;
      dynamicDest.Bn3 = this.Bn3;
      dynamicDest.Hn = this.Hn;
      dynamicDest.Hc = this.Hc;
      dynamicDest.L = this.L;
      dynamicDest.Hn2 = this.Hn2;
      dynamicDest.Hc2 = this.Hc2;
      dynamicDest.Hc3 = this.Hc3;
      dynamicDest.R = this.R;
    }
  }
  public partial class BeamShapeLDegen: SimpleElementBase
  {
    /// <summary>
    /// Width of Cross-section
    /// </summary>
    public System.Double Bw {get; set;}

    /// <summary>
    /// Depth of Cross-section
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Slab thickness of Cross-section
    /// </summary>
    public System.Double H2 {get; set;}

    /// <summary>
    /// Right slab overhang of Cross-section
    /// </summary>
    public System.Double Bw2 {get; set;}

    /// <summary>
    /// Right slab overlap of Cross-section
    /// </summary>
    public System.Double Bw3 {get; set;}

    /// <summary>
    /// Length of bearing area of Cross-section
    /// </summary>
    public System.Double Bla {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.BeamShapeLDegen,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bw = this.Bw;
      dynamicDest.H = this.H;
      dynamicDest.H2 = this.H2;
      dynamicDest.Bw2 = this.Bw2;
      dynamicDest.Bw3 = this.Bw3;
      dynamicDest.Bla = this.Bla;
    }
  }
  public partial class BeamShapeRevU: SimpleElementBase
  {
    /// <summary>
    /// Depth of U-shaped cross-section
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Width of U-shaped cross-section
    /// </summary>
    public System.Double B {get; set;}

    /// <summary>
    /// Thickness of left web of U-shaped cross-section
    /// </summary>
    public System.Double Tl {get; set;}

    /// <summary>
    /// Thickness of right web of U-shaped cross-section
    /// </summary>
    public System.Double Tr {get; set;}

    /// <summary>
    /// Thickness of top slab of U-shaped cross-section
    /// </summary>
    public System.Double Tb {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.BeamShapeRevU,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.H = this.H;
      dynamicDest.B = this.B;
      dynamicDest.Tl = this.Tl;
      dynamicDest.Tr = this.Tr;
      dynamicDest.Tb = this.Tb;
    }
  }
  public partial class BeamShapeTrevDegen: SimpleElementBase
  {
    /// <summary>
    /// Bottom flange width of Inverted T-shape
    /// </summary>
    public System.Double Bbf {get; set;}

    /// <summary>
    /// Bottom flange haunch of Inverted T-shape
    /// </summary>
    public System.Double Bbfh {get; set;}

    /// <summary>
    /// Bottom thickness of web of Inverted T-shape
    /// </summary>
    public System.Double Bw {get; set;}

    /// <summary>
    /// Bottom flange thickness of Inverted T-shape
    /// </summary>
    public System.Double Hbf {get; set;}

    /// <summary>
    /// Bottom flange haunch of Inverted T-shape
    /// </summary>
    public System.Double Hbfh {get; set;}

    /// <summary>
    /// Depth of Inverted T-shape
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Top thickness of web of Inverted T-shape
    /// </summary>
    public System.Double Bc2 {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.BeamShapeTrevDegen,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bbf = this.Bbf;
      dynamicDest.Bbfh = this.Bbfh;
      dynamicDest.Bw = this.Bw;
      dynamicDest.Hbf = this.Hbf;
      dynamicDest.Hbfh = this.Hbfh;
      dynamicDest.H = this.H;
      dynamicDest.Bc2 = this.Bc2;
    }
  }
  public partial class BeamShapeTrevDegenAdd: SimpleElementBase
  {
    /// <summary>
    /// Bottom thickness of web of Cross-section
    /// </summary>
    public System.Double Bw {get; set;}

    /// <summary>
    /// Bottom flange haunch of Cross-section
    /// </summary>
    public System.Double Hbfh {get; set;}

    /// <summary>
    /// Depth of Cross-section
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Slab thickness of Cross-section
    /// </summary>
    public System.Double H3 {get; set;}

    /// <summary>
    /// Slab width of Cross-section
    /// </summary>
    public System.Double Bc {get; set;}

    /// <summary>
    /// Top thickness of web of Cross-section
    /// </summary>
    public System.Double Bc2 {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.BeamShapeTrevDegenAdd,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bw = this.Bw;
      dynamicDest.Hbfh = this.Hbfh;
      dynamicDest.H = this.H;
      dynamicDest.H3 = this.H3;
      dynamicDest.Bc = this.Bc;
      dynamicDest.Bc2 = this.Bc2;
    }
  }
  public partial class BeamShapeTrevChamferHaunchD: SimpleElementBase
  {
    /// <summary>
    /// Bottom flange width of Inverted T-shape
    /// </summary>
    public System.Double Bbf {get; set;}

    /// <summary>
    /// Bottom flange haunch of Inverted T-shape
    /// </summary>
    public System.Double Bbfh {get; set;}

    /// <summary>
    /// Web haunch of Inverted T-shape
    /// </summary>
    public System.Double Bbfh2 {get; set;}

    /// <summary>
    /// Bottom flange thickness of Inverted T-shape
    /// </summary>
    public System.Double Hbf {get; set;}

    /// <summary>
    /// Bottom flange haunch of Inverted T-shape
    /// </summary>
    public System.Double Hbf2 {get; set;}

    /// <summary>
    /// Bottom flange haunch of Inverted T-shape
    /// </summary>
    public System.Double Hbf3 {get; set;}

    /// <summary>
    /// Web thickness of Inverted T-shape
    /// </summary>
    public System.Double Bw {get; set;}

    /// <summary>
    /// Depth of Inverted T-shape
    /// </summary>
    public System.Double H {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.BeamShapeTrevChamferHaunchD,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bbf = this.Bbf;
      dynamicDest.Bbfh = this.Bbfh;
      dynamicDest.Bbfh2 = this.Bbfh2;
      dynamicDest.Hbf = this.Hbf;
      dynamicDest.Hbf2 = this.Hbf2;
      dynamicDest.Hbf3 = this.Hbf3;
      dynamicDest.Bw = this.Bw;
      dynamicDest.H = this.H;
    }
  }
  public partial class BeamShapeTrevChamferHaunchS: SimpleElementBase
  {
    /// <summary>
    /// Bottom flange width of Inverted T-shape
    /// </summary>
    public System.Double Bbf {get; set;}

    /// <summary>
    /// Bottom flange thickness of Inverted T-shape
    /// </summary>
    public System.Double Hbf {get; set;}

    /// <summary>
    /// Bottom flange haunch of Inverted T-shape
    /// </summary>
    public System.Double Hbf2 {get; set;}

    /// <summary>
    /// Bottom flange haunch of Inverted T-shape
    /// </summary>
    public System.Double Hbf3 {get; set;}

    /// <summary>
    /// Web thickness of Inverted T-shape
    /// </summary>
    public System.Double Bw {get; set;}

    /// <summary>
    /// Web haunch of Inverted T-shape
    /// </summary>
    public System.Double Bbfh2 {get; set;}

    /// <summary>
    /// Depth of Inverted T-shape
    /// </summary>
    public System.Double H {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.BeamShapeTrevChamferHaunchS,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bbf = this.Bbf;
      dynamicDest.Hbf = this.Hbf;
      dynamicDest.Hbf2 = this.Hbf2;
      dynamicDest.Hbf3 = this.Hbf3;
      dynamicDest.Bw = this.Bw;
      dynamicDest.Bbfh2 = this.Bbfh2;
      dynamicDest.H = this.H;
    }
  }
  public partial class BeamShapeZDegen: SimpleElementBase
  {
    /// <summary>
    /// Width of joint of Composite cross-section
    /// </summary>
    public System.Double Bn {get; set;}

    /// <summary>
    /// Depth of formwork of Composite cross-section
    /// </summary>
    public System.Double Hn {get; set;}

    /// <summary>
    /// Thickness of left slab of Composite cross-section
    /// </summary>
    public System.Double Hc {get; set;}

    /// <summary>
    /// Left slab overhang of Composite cross-section
    /// </summary>
    public System.Double L {get; set;}

    /// <summary>
    /// Depth of formwork of Composite cross-section
    /// </summary>
    public System.Double Hn2 {get; set;}

    /// <summary>
    /// Thickness of Composite cross-section
    /// </summary>
    public System.Double Hn3 {get; set;}

    /// <summary>
    /// Thickness of right slab of Composite cross-section
    /// </summary>
    public System.Double Hc2 {get; set;}

    /// <summary>
    /// Right slab overhang of Composite cross-section
    /// </summary>
    public System.Double R {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.BeamShapeZDegen,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bn = this.Bn;
      dynamicDest.Hn = this.Hn;
      dynamicDest.Hc = this.Hc;
      dynamicDest.L = this.L;
      dynamicDest.Hn2 = this.Hn2;
      dynamicDest.Hn3 = this.Hn3;
      dynamicDest.Hc2 = this.Hc2;
      dynamicDest.R = this.R;
    }
  }
    /// <summary>
    /// Rectangle
    /// </summary>
  public partial class Rectangle2D: SimpleElementBase
  {
    /// <summary>
    /// Gets, sets width of the rectangle
    /// </summary>
    public System.Double Width {get; set;}

    /// <summary>
    /// Gets, sets height of the rectangle
    /// </summary>
    public System.Double Height {get; set;}

    public System.Double OffsetY {get; set;}

    public System.Double OffsetZ {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.Rectangle2D,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Width = this.Width;
      dynamicDest.Height = this.Height;
      dynamicDest.OffsetY = this.OffsetY;
      dynamicDest.OffsetZ = this.OffsetZ;
    }
  }
    /// <summary>
    /// Rectagle2D for slab
    /// </summary>
  public partial class Rectangle2DCompressionMember: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.Rectangle2DCompressionMember,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
  public partial class Rectangle2DHollow: SimpleElementBase
  {
    /// <summary>
    /// Gets or sets the width of rectangle.
    /// </summary>
    public System.Double B {get; set;}

    /// <summary>
    /// Gets or sets the height of rectangle.
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Gets or sets the thickness of the bottom deck.
    /// </summary>
    public System.Double Tb {get; set;}

    /// <summary>
    /// Gets or sets the thickness of the top deck.
    /// </summary>
    public System.Double Tt {get; set;}

    /// <summary>
    /// Gets or sets the thickness of the left deck.
    /// </summary>
    public System.Double Tl {get; set;}

    /// <summary>
    /// Gets or sets the thickness of the right deck.
    /// </summary>
    public System.Double Tr {get; set;}

    /// <summary>
    /// Gets the centre of gravity related to the y axis.
    /// </summary>
    public System.Double Zt {get; set;}

    /// <summary>
    /// Gets the centre of gravity related to the z axis.
    /// </summary>
    public System.Double Yt {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.Rectangle2DHollow,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.B = this.B;
      dynamicDest.H = this.H;
      dynamicDest.Tb = this.Tb;
      dynamicDest.Tt = this.Tt;
      dynamicDest.Tl = this.Tl;
      dynamicDest.Tr = this.Tr;
      dynamicDest.Zt = this.Zt;
      dynamicDest.Yt = this.Yt;
    }
  }
    /// <summary>
    /// Rectagle2D for slab
    /// </summary>
  public partial class Rectangle2DSlab: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.Rectangle2DSlab,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
    /// <summary>
    /// rectangle 2D for two way slab
    /// </summary>
  public partial class RectangleTwoWaySlab: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.RectangleTwoWaySlab,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
    /// <summary>
    /// Class describes geometry and dimensions of annulus sector
    /// </summary>
  public partial class ShapeAnnulusSector: SimpleElementBase
  {
    /// <summary>
    /// Gets or sets the radius of circle.
    /// </summary>
    public System.Double Radius {get; set;}

    /// <summary>
    /// Gets or sets the wall thickness.
    /// </summary>
    public System.Double Thickness {get; set;}

    /// <summary>
    /// Gets or sets the angle of annulus sector - left side
    /// </summary>
    public System.Double Angle1 {get; set;}

    /// <summary>
    /// Gets or sets the angle of annulus sector - right side
    /// </summary>
    public System.Double Angle2 {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeAnnulusSector,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Radius = this.Radius;
      dynamicDest.Thickness = this.Thickness;
      dynamicDest.Angle1 = this.Angle1;
      dynamicDest.Angle2 = this.Angle2;
    }
  }
  public partial class ShapeI: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeI,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
  public partial class ShapeIBase: SimpleElementBase
  {
    /// <summary>
    /// Gets, sets total height
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Gets, sets width of the upper part (btf)
    /// </summary>
    public System.Double Bh {get; set;}

    /// <summary>
    /// Gets, sets width of the bottom part (bbf)
    /// </summary>
    public System.Double Bs {get; set;}

    /// <summary>
    /// Gets, sets thickness of the bottom part (hbf)
    /// </summary>
    public System.Double Ts {get; set;}

    /// <summary>
    /// Gets, sets thickness of the upper part (htf)
    /// </summary>
    public System.Double Th {get; set;}

    /// <summary>
    /// Gets, sets width of the web
    /// </summary>
    public System.Double Tw {get; set;}

    /// <summary>
    /// Gets, sets the top flange haunch.
    /// </summary>
    public System.Double Tfh {get; set;}

    /// <summary>
    /// Gets, sets the bottom flange haunch.
    /// </summary>
    public System.Double Bfh {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeIBase,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.H = this.H;
      dynamicDest.Bh = this.Bh;
      dynamicDest.Bs = this.Bs;
      dynamicDest.Ts = this.Ts;
      dynamicDest.Th = this.Th;
      dynamicDest.Tw = this.Tw;
      dynamicDest.Tfh = this.Tfh;
      dynamicDest.Bfh = this.Bfh;
    }
  }
  public partial class ShapeL: SimpleElementBase
  {
    public System.Double B {get; set;}

    /// <summary>
    /// in dialog for input the parameter si name as hf
    /// </summary>
    public System.Double Th {get; set;}

    /// <summary>
    /// in dialog for input the parameter si name as bw
    /// </summary>
    public System.Double Sh {get; set;}

    public System.Double H {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeL,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.B = this.B;
      dynamicDest.Th = this.Th;
      dynamicDest.Sh = this.Sh;
      dynamicDest.H = this.H;
    }
  }
  public partial class ShapeLl: SimpleElementBase
  {
    public System.Double B {get; set;}

    public System.Double Th {get; set;}

    public System.Double Sh {get; set;}

    public System.Double H {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeLl,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.B = this.B;
      dynamicDest.Th = this.Th;
      dynamicDest.Sh = this.Sh;
      dynamicDest.H = this.H;
    }
  }
    /// <summary>
    /// Represents a shape of circle.
    /// </summary>
  public partial class ShapeO: SimpleElementBase
  {
    /// <summary>
    /// Gets or sets the diameter of circle.
    /// </summary>
    public System.Double Diameter {get; set;}

    /// <summary>
    /// Gets or sets the radius of circle.
    /// </summary>
    public System.Double Radius {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeO,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Diameter = this.Diameter;
      dynamicDest.Radius = this.Radius;
    }
  }
  public partial class ShapeOHollow: SimpleElementBase
  {
    /// <summary>
    /// Gets or sets the diameter of circle.
    /// </summary>
    public System.Double Diameter {get; set;}

    /// <summary>
    /// Gets or sets the radius of circle.
    /// </summary>
    public System.Double Radius {get; set;}

    /// <summary>
    /// Gets or sets the wall thickness.
    /// </summary>
    public System.Double Thickness {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeOHollow,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Diameter = this.Diameter;
      dynamicDest.Radius = this.Radius;
      dynamicDest.Thickness = this.Thickness;
    }
  }
    /// <summary>
    /// Represents a shape of circle.
    /// </summary>
  public partial class ShapeOval: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeOval,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
    /// <summary>
    /// Represents the S shape.
    /// </summary>
  public partial class ShapeS: SimpleElementBase
  {
    /// <summary>
    /// Gets or sets the width of top flange
    /// </summary>
    public System.Double Bt {get; set;}

    /// <summary>
    /// Gets or sets the width of bottom flange
    /// </summary>
    public System.Double Bb {get; set;}

    /// <summary>
    /// Gets or sets the width of wall of z shape
    /// </summary>
    public System.Double Bw {get; set;}

    /// <summary>
    /// Gets or sets the height of z shape
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Gets or sets the thickness of the top flange
    /// </summary>
    public System.Double Tt {get; set;}

    /// <summary>
    /// Gets or sets the thickness of the bottom flange
    /// </summary>
    public System.Double Tb {get; set;}

    /// <summary>
    /// Gets the centre of gravity related to the y axis.
    /// </summary>
    public System.Double Zt {get; set;}

    /// <summary>
    /// Gets the centre of gravity related to the z axis.
    /// </summary>
    public System.Double Yt {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeS,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bt = this.Bt;
      dynamicDest.Bb = this.Bb;
      dynamicDest.Bw = this.Bw;
      dynamicDest.H = this.H;
      dynamicDest.Tt = this.Tt;
      dynamicDest.Tb = this.Tb;
      dynamicDest.Zt = this.Zt;
      dynamicDest.Yt = this.Yt;
    }
  }
    /// <summary>
    /// Represents a simply T shape.
    /// </summary>
  public partial class ShapeT: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeT,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
    /// <summary>
    /// Represents a T shape with flange haunch.
    /// </summary>
  public partial class ShapeT1: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeT1,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
    /// <summary>
    /// Represents a T shape with wall haunch.
    /// </summary>
  public partial class ShapeT2: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeT2,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
    /// <summary>
    /// Shape of Assymetrical T
    /// </summary>
  public partial class ShapeTAssym: SimpleElementBase
  {
    public System.Double Bfl {get; set;}

    public System.Double Bfr {get; set;}

    public System.Double Bfll {get; set;}

    public System.Double Bfrr {get; set;}

    public System.Double Tw {get; set;}

    public System.Double Tfr {get; set;}

    public System.Double Tfl {get; set;}

    public System.Double H {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeTAssym,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bfl = this.Bfl;
      dynamicDest.Bfr = this.Bfr;
      dynamicDest.Bfll = this.Bfll;
      dynamicDest.Bfrr = this.Bfrr;
      dynamicDest.Tw = this.Tw;
      dynamicDest.Tfr = this.Tfr;
      dynamicDest.Tfl = this.Tfl;
      dynamicDest.H = this.H;
    }
  }
    /// <summary>
    /// Assymetrical T Shape with flange on bottom side.
    /// </summary>
  public partial class ShapeTAssymRev: SimpleElementBase
  {
    public System.Double Bfl {get; set;}

    public System.Double Bfr {get; set;}

    public System.Double Tw {get; set;}

    public System.Double Tfr {get; set;}

    public System.Double Tfl {get; set;}

    public System.Double H {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeTAssymRev,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bfl = this.Bfl;
      dynamicDest.Bfr = this.Bfr;
      dynamicDest.Tw = this.Tw;
      dynamicDest.Tfr = this.Tfr;
      dynamicDest.Tfl = this.Tfl;
      dynamicDest.H = this.H;
    }
  }
  public partial class ShapeTBase: SimpleElementBase
  {
    public System.Double Height {get; set;}

    public System.Double Width {get; set;}

    public System.Double TopFlangeWidth {get; set;}

    public System.Double WallWidth {get; set;}

    public System.Double WallHaunch {get; set;}

    public System.Double TopFlangeHaunch {get; set;}

    public System.Double Zt {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeTBase,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Height = this.Height;
      dynamicDest.Width = this.Width;
      dynamicDest.TopFlangeWidth = this.TopFlangeWidth;
      dynamicDest.WallWidth = this.WallWidth;
      dynamicDest.WallHaunch = this.WallHaunch;
      dynamicDest.TopFlangeHaunch = this.TopFlangeHaunch;
      dynamicDest.Zt = this.Zt;
    }
  }
    /// <summary>
    /// Represents a T shape with chamfer between top flange and wall.
    /// </summary>
  public partial class ShapeTChamfer1: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeTChamfer1,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
    /// <summary>
    /// Represents a T shape with chamfer between top flange and wall.
    /// </summary>
  public partial class ShapeTChamfer2: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeTChamfer2,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
    /// <summary>
    /// Represents general T shape with chamfer between top flange and wall.
    /// The wall and flange can have double haunch.
    /// </summary>
  public partial class ShapeTChamferBase: SimpleElementBase
  {
    /// <summary>
    /// Gets or sets the total shape height.
    /// </summary>
    public System.Double Height {get; set;}

    /// <summary>
    /// Gets or sets the total shape width.
    /// </summary>
    public System.Double Width {get; set;}

    /// <summary>
    /// Gets or sets the top flange thickness.
    /// </summary>
    public System.Double TopFlangeWidth {get; set;}

    /// <summary>
    /// Gets or sets the wall thickness.
    /// </summary>
    public System.Double WallWidth {get; set;}

    /// <summary>
    /// Gets or sets the wall haunch.
    /// </summary>
    public System.Double WallHaunch1 {get; set;}

    /// <summary>
    /// Gets or sets the second wall haunch (chamfer).
    /// </summary>
    public System.Double WallHaunch2 {get; set;}

    /// <summary>
    /// Gets or sets the top flange haunch.
    /// </summary>
    public System.Double TopFlangeHaunch1 {get; set;}

    /// <summary>
    /// Gets or sets the second top flange haunch (chamfer).
    /// </summary>
    public System.Double TopFlangeHaunch2 {get; set;}

    /// <summary>
    /// Gets the centre of gravity related to the y axis.
    /// </summary>
    public System.Double Zt {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeTChamferBase,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Height = this.Height;
      dynamicDest.Width = this.Width;
      dynamicDest.TopFlangeWidth = this.TopFlangeWidth;
      dynamicDest.WallWidth = this.WallWidth;
      dynamicDest.WallHaunch1 = this.WallHaunch1;
      dynamicDest.WallHaunch2 = this.WallHaunch2;
      dynamicDest.TopFlangeHaunch1 = this.TopFlangeHaunch1;
      dynamicDest.TopFlangeHaunch2 = this.TopFlangeHaunch2;
      dynamicDest.Zt = this.Zt;
    }
  }
    /// <summary>
    /// The upside down T shape.
    /// </summary>
  public partial class ShapeTrev: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeTrev,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
    /// <summary>
    /// The upside down T shape.
    /// </summary>
  public partial class ShapeTrev1: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeTrev1,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
    /// <summary>
    /// Represents a T shape with wall haunch.
    /// </summary>
  public partial class ShapeTrev2: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeTrev2,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
    /// <summary>
    /// The upside down T shape.
    /// </summary>
  public partial class ShapeTrevBase: SimpleElementBase
  {
    public System.Double Height {get; set;}

    public System.Double Width {get; set;}

    public System.Double TopFlangeWidth {get; set;}

    public System.Double WallWidth {get; set;}

    public System.Double WallHaunch {get; set;}

    public System.Double TopFlangeHaunch {get; set;}

    /// <summary>
    /// Gets the centre of gravity related to the y axis.
    /// </summary>
    public System.Double Zt {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeTrevBase,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Height = this.Height;
      dynamicDest.Width = this.Width;
      dynamicDest.TopFlangeWidth = this.TopFlangeWidth;
      dynamicDest.WallWidth = this.WallWidth;
      dynamicDest.WallHaunch = this.WallHaunch;
      dynamicDest.TopFlangeHaunch = this.TopFlangeHaunch;
      dynamicDest.Zt = this.Zt;
    }
  }
    /// <summary>
    /// Represents a simply T shape.
    /// </summary>
  public partial class ShapeTT: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeTT,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
    /// <summary>
    /// Represents a simply T shape.
    /// </summary>
  public partial class ShapeTT1: SimpleElementBase
  {
    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeTT1,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
    }
  }
  public partial class ShapeTTBase: SimpleElementBase
  {
    public System.Double Height {get; set;}

    public System.Double Width {get; set;}

    public System.Double TopFlangeWidth {get; set;}

    public System.Double WallWidth {get; set;}

    public System.Double WallHaunch1 {get; set;}

    public System.Double WallHaunch2 {get; set;}

    public System.Double TopFlangeHaunch {get; set;}

    public System.Double WallSpace {get; set;}

    public System.Double Zt {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeTTBase,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Height = this.Height;
      dynamicDest.Width = this.Width;
      dynamicDest.TopFlangeWidth = this.TopFlangeWidth;
      dynamicDest.WallWidth = this.WallWidth;
      dynamicDest.WallHaunch1 = this.WallHaunch1;
      dynamicDest.WallHaunch2 = this.WallHaunch2;
      dynamicDest.TopFlangeHaunch = this.TopFlangeHaunch;
      dynamicDest.WallSpace = this.WallSpace;
      dynamicDest.Zt = this.Zt;
    }
  }
    /// <summary>
    /// Represents the U shape.
    /// </summary>
  public partial class ShapeU: SimpleElementBase
  {
    /// <summary>
    /// Gets or sets the width of rectangle.
    /// </summary>
    public System.Double B {get; set;}

    /// <summary>
    /// Gets or sets the height of rectangle.
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Gets or sets the thickness of the bottom deck.
    /// </summary>
    public System.Double Tb {get; set;}

    /// <summary>
    /// Gets or sets the thickness of the left deck.
    /// </summary>
    public System.Double Tl {get; set;}

    /// <summary>
    /// Gets or sets the thickness of the right deck.
    /// </summary>
    public System.Double Tr {get; set;}

    /// <summary>
    /// Gets the centre of gravity related to the y axis.
    /// </summary>
    public System.Double Zt {get; set;}

    /// <summary>
    /// Gets the centre of gravity related to the z axis.
    /// </summary>
    public System.Double Yt {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeU,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.B = this.B;
      dynamicDest.H = this.H;
      dynamicDest.Tb = this.Tb;
      dynamicDest.Tl = this.Tl;
      dynamicDest.Tr = this.Tr;
      dynamicDest.Zt = this.Zt;
      dynamicDest.Yt = this.Yt;
    }
  }
    /// <summary>
    /// Represents the Z shape.
    /// </summary>
  public partial class ShapeZ: SimpleElementBase
  {
    /// <summary>
    /// Gets or sets the width of top flange
    /// </summary>
    public System.Double Bt {get; set;}

    /// <summary>
    /// Gets or sets the width of bottom flange
    /// </summary>
    public System.Double Bb {get; set;}

    /// <summary>
    /// Gets or sets the width of wall of z shape
    /// </summary>
    public System.Double Bw {get; set;}

    /// <summary>
    /// Gets or sets the height of z shape
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Gets or sets the thickness of the top flange
    /// </summary>
    public System.Double Tt {get; set;}

    /// <summary>
    /// Gets or sets the thickness of the bottom flange
    /// </summary>
    public System.Double Tb {get; set;}

    /// <summary>
    /// Gets the centre of gravity related to the y axis.
    /// </summary>
    public System.Double Zt {get; set;}

    /// <summary>
    /// Gets the centre of gravity related to the z axis.
    /// </summary>
    public System.Double Yt {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.ShapeZ,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Bt = this.Bt;
      dynamicDest.Bb = this.Bb;
      dynamicDest.Bw = this.Bw;
      dynamicDest.H = this.H;
      dynamicDest.Tt = this.Tt;
      dynamicDest.Tb = this.Tb;
      dynamicDest.Zt = this.Zt;
      dynamicDest.Yt = this.Yt;
    }
  }
  public partial class CssSteelAngle: SimpleElementBase
  {
    /// <summary>
    /// root radius.
    /// </summary>
    public System.Double Rw {get; set;}

    /// <summary>
    /// Overall depth.
    /// </summary>
    public System.Double Depth {get; set;}

    /// <summary>
    /// Flange width.
    /// </summary>
    public System.Double Width {get; set;}

    /// <summary>
    /// Flange thickness.
    /// </summary>
    public System.Double Thickness {get; set;}

    /// <summary>
    /// Buckling depth
    /// </summary>
    public System.Double ToeRadius {get; set;}

    /// <summary>
    /// centroid position
    /// </summary>
    public System.Double CentroidPosition {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.Shapes.Steel.CssSteelAngle,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Rw = this.Rw;
      dynamicDest.Depth = this.Depth;
      dynamicDest.Width = this.Width;
      dynamicDest.Thickness = this.Thickness;
      dynamicDest.ToeRadius = this.ToeRadius;
      dynamicDest.CentroidPosition = this.CentroidPosition;
    }
  }
  public partial class CssSteelCircularHollow: SimpleElementBase
  {
    public System.Double Radius {get; set;}

    public System.Double Thickness {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.Shapes.Steel.CssSteelCircularHollow,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Radius = this.Radius;
      dynamicDest.Thickness = this.Thickness;
    }
  }
  public partial class CssSteelChannel: SimpleElementBase
  {
    /// <summary>
    /// root radius.
    /// </summary>
    public System.Double Rw {get; set;}

    /// <summary>
    /// Overall depth.
    /// </summary>
    public System.Double Depth {get; set;}

    /// <summary>
    /// Flange width.
    /// </summary>
    public System.Double Width {get; set;}

    /// <summary>
    /// Flange thickness.
    /// </summary>
    public System.Double Tf {get; set;}

    /// <summary>
    /// Web thickness.
    /// </summary>
    public System.Double Tw {get; set;}

    /// <summary>
    /// Buckling depth
    /// </summary>
    public System.Double BucklingDepth {get; set;}

    /// <summary>
    /// flange taper
    /// </summary>
    public System.Double FlangeTaper {get; set;}

    /// <summary>
    /// centroid position
    /// </summary>
    public System.Double CentroidPosition {get; set;}

    /// <summary>
    /// flange radius.
    /// </summary>
    public System.Double Rf {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.Shapes.Steel.CssSteelChannel,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Rw = this.Rw;
      dynamicDest.Depth = this.Depth;
      dynamicDest.Width = this.Width;
      dynamicDest.Tf = this.Tf;
      dynamicDest.Tw = this.Tw;
      dynamicDest.BucklingDepth = this.BucklingDepth;
      dynamicDest.FlangeTaper = this.FlangeTaper;
      dynamicDest.CentroidPosition = this.CentroidPosition;
      dynamicDest.Rf = this.Rf;
    }
  }
  public partial class CssSteelRectangularHollow: SimpleElementBase
  {
    public System.Double Depth {get; set;}

    public System.Double Width {get; set;}

    public System.Double Thickness {get; set;}

    public System.Double InnerRadius {get; set;}

    public System.Double OuterRadius {get; set;}

    public System.Double WebBucklingDepth {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.Shapes.Steel.CssSteelRectangularHollow,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Depth = this.Depth;
      dynamicDest.Width = this.Width;
      dynamicDest.Thickness = this.Thickness;
      dynamicDest.InnerRadius = this.InnerRadius;
      dynamicDest.OuterRadius = this.OuterRadius;
      dynamicDest.WebBucklingDepth = this.WebBucklingDepth;
    }
  }
  public partial class CssSteelShapeIrec: SimpleElementBase
  {
    /// <summary>
    /// Web root radius.
    /// </summary>
    public System.Double Arc {get; set;}

    /// <summary>
    /// Overall depth.
    /// </summary>
    public System.Double Height {get; set;}

    /// <summary>
    /// Flange width.
    /// </summary>
    public System.Double Width {get; set;}

    /// <summary>
    /// Flange thickness.
    /// </summary>
    public System.Double FlangeThickness {get; set;}

    /// <summary>
    /// Web thickness.
    /// </summary>
    public System.Double WebThickness {get; set;}

    /// <summary>
    /// Flange edge radius.
    /// </summary>
    public System.Double R1 {get; set;}

    /// <summary>
    /// Flange Tapper.
    /// </summary>
    public System.Double TapperF {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.CssSteelShapeIrec,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Arc = this.Arc;
      dynamicDest.Height = this.Height;
      dynamicDest.Width = this.Width;
      dynamicDest.FlangeThickness = this.FlangeThickness;
      dynamicDest.WebThickness = this.WebThickness;
      dynamicDest.R1 = this.R1;
      dynamicDest.TapperF = this.TapperF;
    }
  }
  public partial class CssSteelShapeThinWall: SimpleElementBase
  {
    public System.Double Radius {get; set;}

    public System.Double Thickness {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.CssSteelShapeThinWall,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.Radius = this.Radius;
      dynamicDest.Thickness = this.Thickness;
    }
  }
  public partial class CssSteelShapeTrec: SimpleElementBase
  {
    /// <summary>
    /// Web root radius.
    /// </summary>
    public System.Double R {get; set;}

    /// <summary>
    /// Flange rounding.
    /// </summary>
    public System.Double R1 {get; set;}

    /// <summary>
    /// Web rounding.
    /// </summary>
    public System.Double R2 {get; set;}

    /// <summary>
    /// Overall height
    /// </summary>
    public System.Double Height {get; set;}

    /// <summary>
    /// overall width
    /// </summary>
    public System.Double Width {get; set;}

    /// <summary>
    /// Flange thickness
    /// </summary>
    public System.Double Tf {get; set;}

    /// <summary>
    /// Web thickness
    /// </summary>
    public System.Double Tw {get; set;}

    /// <summary>
    /// flange tapper (angle in radians)
    /// </summary>
    public System.Double Tapperf {get; set;}

    /// <summary>
    /// web tapper (angle in radians)
    /// </summary>
    public System.Double Tapperw {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.CssSteelShapeTrec,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.R = this.R;
      dynamicDest.R1 = this.R1;
      dynamicDest.R2 = this.R2;
      dynamicDest.Height = this.Height;
      dynamicDest.Width = this.Width;
      dynamicDest.Tf = this.Tf;
      dynamicDest.Tw = this.Tw;
      dynamicDest.Tapperf = this.Tapperf;
      dynamicDest.Tapperw = this.Tapperw;
    }
  }
    /// <summary>
    /// Symetric trapezoid defined by bottom and top width.
    /// </summary>
  public partial class Trapezoid1: SimpleElementBase
  {
    /// <summary>
    /// Gets, sets height of the trapezoid core.
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Gets or sets the top width.
    /// </summary>
    public System.Double Bt {get; set;}

    /// <summary>
    /// Gets or sets the bottom width.
    /// </summary>
    public System.Double Bb {get; set;}

    /// <summary>
    /// Gets the centre of gravity related to the y axis.
    /// </summary>
    public System.Double Zt {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.Trapezoid1,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.H = this.H;
      dynamicDest.Bt = this.Bt;
      dynamicDest.Bb = this.Bb;
      dynamicDest.Zt = this.Zt;
    }
  }
    /// <summary>
    /// Unsymetric trapezoid
    /// </summary>
  public partial class Trapezoid3: SimpleElementBase
  {
    /// <summary>
    /// Gets, sets width of the trapezoid core.
    /// </summary>
    public System.Double B {get; set;}

    /// <summary>
    /// Gets, sets height of the trapezoid core.
    /// </summary>
    public System.Double H {get; set;}

    /// <summary>
    /// Gets or sets the bottom left width.
    /// </summary>
    public System.Double Btl {get; set;}

    /// <summary>
    /// Gets or sets the bottom right width.
    /// </summary>
    public System.Double Btr {get; set;}

    /// <summary>
    /// Gets the centre of gravity related to the z axis.
    /// </summary>
    public System.Double Yt {get; set;}

    /// <summary>
    /// Gets the centre of gravity related to the y axis.
    /// </summary>
    public System.Double Zt {get; set;}

    public override Type GetStructClsType()
    {
      return Type.GetType("CI.Geometry2D.Trapezoid3,CI.Geometry2D");
    }

    public override void CopyToSM(object destination)
    {
      dynamic dynamicDest = destination;
      dynamicDest.B = this.B;
      dynamicDest.H = this.H;
      dynamicDest.Btl = this.Btl;
      dynamicDest.Btr = this.Btr;
      dynamicDest.Yt = this.Yt;
      dynamicDest.Zt = this.Zt;
    }
  }
}


