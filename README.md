# Face Detection and ID Photo Cropper

A small Windows Forms application (C# / .NET Framework / Emgu CV) that finds faces in
photos and exports a standardized **248 x 340 px** ID-style portrait for the largest
face in each image. Results are written as PNG files into a `PROCESS` folder next to
the source image, so batch runs never mix input and output.

The interface is entirely in English and is organized into a three-pane layout: file
list on the left, annotated original in the middle, cropped result on the right.

---

## Features

- **Batch processing** - add many images at once through the file dialog or drag and
  drop them onto the list.
- **Side-by-side preview** - the original image with every detected face outlined, and
  the exported ID photo, updated as each file is processed.
- **Standardized output** - the largest detected face is scaled so its width becomes
  197 px and is centered on a white 248 x 340 canvas, producing a consistent portrait
  size regardless of the source resolution.
- **Safe cropping** - the source region is clamped by drawing onto a fixed-size canvas,
  so faces near an image edge no longer produce broken or empty crops.
- **Responsive layout** - the window can be resized or maximized; previews and the file
  list grow with it. Minimum window size is 1024 x 640.
- **Batch progress** - a status bar shows the current file and a progress bar tracks the
  batch.
- **No file locks** - images are read through a stream and copied, so source files can be
  moved or deleted afterwards.
- **Keyboard shortcut** - select entries in the list and press `Delete` to remove them.
- **Open output folder** - jumps straight to the `PROCESS` folder of the first selected
  image.

## Requirements

| Item | Requirement |
| --- | --- |
| OS | Windows 7 SP1 or later (64-bit) |
| Runtime | .NET Framework 4.8 |
| Platform | x64 - the bundled native Emgu CV libraries are 64-bit only |
| Build | Visual Studio 2017 or newer, or MSBuild 15+ |
| Library | Emgu CV 3.1.0.2282 (managed and native binaries included) |

The Emgu CV managed assemblies (`Emgu.CV.World.dll`, `Emgu.CV.UI.dll`,
`Emgu.CV.UI.GL.dll`, `ZedGraph.dll`) live in the project folder and are referenced from
there. The native runtime (`cvextern.dll`, `opencv_ffmpeg310_64.dll`, `msvcp120.dll`,
`msvcr120.dll`) is in the `x64` folder and is copied to `bin\Debug\x64` on build.

## Build

1. Open `DetectFaceAndCrop.sln` in Visual Studio.
2. Select the `Debug` or `Release` configuration and build.

Command line:

```powershell
msbuild DetectFaceAndCrop.sln /p:Configuration=Debug /p:Platform="Any CPU"
```

The project targets .NET Framework 4.8 and is built for x64 (the native OpenCV
binaries are 64-bit only). If your Visual Studio installation does not include the
4.8 targeting pack, install the *.NET Framework 4.8 Developer Pack* first.

## Usage

1. Start `DetectFaceAndCrop.exe`.
2. Click **Add images...** and select one or more photos (`.jpg`, `.jpeg`, `.png`,
   `.bmp`, `.gif`), or drag files onto the list.
3. Click **Process images**. Every file is decoded, scanned for faces, and the largest
   face is exported.
4. Check the two previews:
   - **Original - detected faces**: all detections are outlined in light blue.
   - **Result - ID photo (248 x 340)**: the exact bitmap that was saved.
5. Use **Open output folder** to inspect the results.

### Output

For a source image `C:\Photos\portrait.jpg` the result is:

```
C:\Photos\PROCESS\portrait.png
```

An existing file with the same name is overwritten. Images without a detected face are
skipped (the status bar counts them) and nothing is written for them.

## How it works

1. The image is loaded into an Emgu CV `Image<Bgr, byte>` and converted to grayscale.
2. `CascadeClassifier.DetectMultiScale` runs the frontal-face Haar cascade with
   `scaleFactor = 1.1`, `minNeighbors = 10` and a minimum face size of 40 x 40 px.
3. All faces are drawn on the preview. The largest face (by area) is chosen for export.
4. The source is resized so the chosen face is 197 px wide
   (`scale = 197 / face.Width`), and the scaled image is drawn onto a white
   248 x 340 bitmap so that the face center lands at `(128, 150)`.
5. The card is saved as PNG. Because the face center is placed on a fixed canvas, faces
   near the image border are padded with white rather than producing an invalid crop.

### Tuning constants

All detection and output settings live at the top of `DetectFaceAndCrop\Form1.cs`:

| Constant | Value | Meaning |
| --- | --- | --- |
| `FaceScaleFactor` | 1.1 | Pyramid scale step used by the cascade |
| `FaceMinNeighbors` | 10 | Higher = fewer but more confident detections |
| `MinFaceSize` | 40 | Faces smaller than this are ignored |
| `OutputWidth` / `OutputHeight` | 248 / 340 | Exported photo size in pixels |
| `TargetFaceWidth` | 197 | Face width after scaling |
| `FaceCenterX` / `FaceCenterY` | 128 / 150 | Face center position on the card |

## Project structure

```
DetectFaceAndCrop/
|-- DetectFaceAndCrop.sln          Solution file
|-- README.md                      This document
|-- LICENSE                        MIT license for this project
|-- .gitignore                     Excludes bin/, obj/, .vs/
|-- image_test/                    Sample photos (+ PROCESS outputs)
|-- third_party/                   License texts of bundled dependencies
`-- DetectFaceAndCrop/
    |-- Form1.cs                   UI logic, detection and cropping
    |-- Form1.Designer.cs          Layout (English labels)
    |-- Form1.resx                 Form resources
    |-- Program.cs                 Application entry point
    |-- App.config                 Runtime configuration
    |-- DetectFaceAndCrop.csproj   Project file (references, native copies)
    |-- Properties/                Assembly info and settings
    |-- haarcascade_frontalface_default.xml   Haar cascade model
    |-- haarcascade_eye.xml        Eye cascade (shipped, not used)
    |-- Emgu.CV.World.dll          Emgu CV managed library
    |-- Emgu.CV.UI.dll             Emgu CV WinForms controls (ImageBox)
    |-- Emgu.CV.UI.GL.dll          Emgu CV OpenGL UI helper
    |-- ZedGraph.dll               Charting dependency of Emgu.CV.UI
    `-- x64/                       Native Emgu CV / OpenCV / VC++ runtime
```

## Troubleshooting

**"BadImageFormatException" when starting or processing**

The application and the bundled native libraries are 64-bit. Make sure you run the
x64 build on 64-bit Windows and that the `x64` subfolder sits next to
`DetectFaceAndCrop.exe`. The project copies it automatically on build. Do not enable
"Prefer 32-bit".

**Missing `cvextern` / `msvcp120` / `msvcr120` DLL**

Confirm that `bin\Debug\x64` contains `cvextern.dll`, `opencv_ffmpeg310_64.dll`,
`msvcp120.dll` and `msvcr120.dll`. If you replace the Emgu CV assemblies, replace the
native runtime with the **same** Emgu CV version (3.1.0.2282) - mixing managed 3.x with
an older `cvextern.dll` produces an `EntryPointNotFoundException` at startup.

**No faces are detected**

The Haar cascade only recognizes roughly frontal faces. Very small faces (under 40 px),
heavy rotation, strong backlight, or low resolution will be missed. Lower
`MinFaceSize` / `FaceMinNeighbors` in `Form1.cs`, or use sharper, front-facing photos.

**Build error MSB3644 (reference assemblies for v4.8 not found)**

Install the .NET Framework 4.8 Developer Pack, or retarget the project to the framework
version installed on your machine.

## Limitations

- One exported portrait per source image (the largest face). Group photos keep only the
  most prominent person.
- Detection is a classic Haar cascade, not a modern deep-learning detector; accuracy is
  lower on non-frontal, occluded, or very low-resolution faces.
- Cropping uses fixed framing tuned for ID photos (face centered slightly above the
  middle); it is not a passport-photo compliance checker.
- Processing is synchronous and cannot be cancelled mid-batch. Large batches block the
  window until each image is finished, though the status bar updates after every file.

## License

This project's source code is released under the **MIT License**. See the
[LICENSE](LICENSE) file for the full text.

The bundled Emgu CV runtime and managed assemblies are third-party software distributed
under the **GNU General Public License v3** (a commercial Emgu CV license is also
available from Emgu Corporation). They are not covered by the MIT license above, and
redistributing them requires compliance with their own license terms. OpenCV and the
Visual C++ runtime DLLs keep their respective licenses as well.

## Credits

- Original sample: *"[C#] Detect Face and Crop EmguCV" - laptrinhvb.net*.
- [Emgu CV](https://www.emgu.com/) - .NET wrapper for OpenCV.
- The UI layout, English labels, batch handling, runtime packaging, and documentation
  were revised in this version.
